using Bost.Agent.State;
using Bost.Proto.Enum;
using Bost.Proto.Packet;
using Bost.Proto.Packet.Handshaking.Serverbound;
using Bost.Proto.Packet.Login.Serverbound;
using Bost.Proto.Types;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Bost.Agent
{
	public class Agent
	{
		public Guid Id { get; }
		public delegate void MessageHandler(object sender, byte[] message);

		public event MessageHandler OnRecive;
		public event MessageHandler OnSend;

		public readonly GameState gameState;

		private readonly Socket _socket;
		private readonly string _server;
		private readonly ushort _port;
		public Agent(string server, ushort port)
		{
			gameState = new GameState();
			_server = server;
			_port = port;
			_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_socket.Connect(server, port);
			StartRecive();
			Id = Guid.NewGuid();
		}

		private Task StartRecive()
		{
			return Task.Run(() =>
			{
				byte[] array = new byte[256];
				while (_socket.Connected)
				{
					int length = _socket.Receive(array);
					if (length > 0)
					{
						OnRecive.Invoke(this, array[0..length]);
					}
				}
			});
		}

		public async Task Send(byte[] array)
		{
			OnSend?.Invoke(this, array);
			await _socket.SendAsync(array, SocketFlags.None);
		}

		public async Task Send(BasePacket basePacket)
		{
			List<byte> toSend = new List<byte>();
			Write(basePacket, true, toSend);
			await Send(toSend.ToArray());
		}

		public async Task Login(string nickname)
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
				Name = nickname
			};
			Write(loginStartPacket, false, toSend);
			await Send(toSend.ToArray());
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
	}
}
