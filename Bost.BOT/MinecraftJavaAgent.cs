using Bost.Proto.Enum;
using Bost.Proto.Packet;
using Bost.Proto.Packet.Handshaking.Serverbound;
using Bost.Proto.Packet.Login.Serverbound;
using Bost.Proto.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent
{
	public abstract class MinecraftJavaAgent
	{
		private Socket _socket;
		private int _timeout;
		private const int _timeoutAmount = 5000;
		private const int _packetAwait = 100;
		private readonly CancellationToken _cancellationToken;
		private readonly Queue<byte[]> _commandQueue;

		protected readonly string _server;
		protected readonly ushort _port;
		protected readonly string _nickname;

		public delegate void MessageHandler(object sender, byte[] message);
		public event MessageHandler OnRecive;
		public event MessageHandler OnSend;
		public event MessageHandler Reset;

		public MinecraftJavaAgent(string server, ushort port, string nickname)
		{
			_server = server;
			_port = port;
			_nickname = nickname;
			_commandQueue = new Queue<byte[]>();
			_cancellationToken = new CancellationToken();
			StartRecive();
		}


		private Task StartRecive()
		{
			return Task.Run(async () =>
			{
				while (!_cancellationToken.IsCancellationRequested)
				{
					using (_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
					{
						try
						{
							_socket.Connect(_server, _port);
							await Login();
							while (_commandQueue.Any())
							{
								var queued = _commandQueue.Dequeue();
								await SendArray(queued);
							}
							byte[] array = new byte[256];
							while (_socket.Connected && !_cancellationToken.IsCancellationRequested)
							{
								int length = _socket.Receive(array);
								if (length > 0)
								{
									_timeout = 0;
									OnRecive.Invoke(this, array[0..length]);
								}
								else
								{

									await Task.Delay(_packetAwait);
									_timeout += _packetAwait;
									if (_timeout > _timeoutAmount) _socket.Disconnect(false);
								}
							}
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
						}
					}
					Reset.Invoke(this, null);
					await Task.Delay(10 * 1000);
				}
			});
		}

		private Task Login()
		{
			HandshakePacket handshakePacket = new HandshakePacket()
			{
				ProtocolVersion = Program.CurrentProto,
				Address = _server,
				Port = _port,
				LoginState = LoginStates.Login,
			};
			List<byte> toSend = new List<byte>();
			Write(handshakePacket, false, toSend);

			LoginStartPacket loginStartPacket = new LoginStartPacket()
			{
				Name = _nickname
			};
			Write(loginStartPacket, false, toSend);
			return Send(toSend.ToArray());
		}

		public void Write(BasePacket packet, bool encrypt = true, List<byte> toSend = null)
		{
			byte[] data = packet.Write();
			if (toSend == null)
			{
				toSend = new List<byte>();
			}

			if (encrypt)
			{
				toSend.AddRange(McVarint.ToBytes(data.Length + 2));
				toSend.AddRange(McVarint.ToBytes(0));
			}
			else
			{
				toSend.AddRange(McVarint.ToBytes(data.Length + 1));
			}

			toSend.AddRange(McVarint.ToBytes(packet.PacketId));
			toSend.AddRange(data);
		}

		private async Task Send(byte[] array)
		{
			if (_socket == null || _socket.Connected == false)
			{
				_commandQueue.Enqueue(array);
			}
			else
			{
				await SendArray(array);
			}
		}

		private async Task SendArray(byte[] array)
		{
			OnSend?.Invoke(this, array);
			await _socket.SendAsync(array, SocketFlags.None);
		}

		public async Task Send<T>(T basePacket) where T : BasePacket
		{
			List<byte> toSend = new List<byte>();
			Write(basePacket, true, toSend);
			await Send(toSend.ToArray());
		}
	}
}
