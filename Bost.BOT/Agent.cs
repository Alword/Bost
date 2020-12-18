using Bost.Agent.AgentEventHandlers;
using Bost.Agent.State;
using Bost.Proto;
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
		public readonly GameState GameState;
		public readonly ConnectionListner ConnectionListner;



		private readonly Socket _socket;
		private readonly string _server;
		private readonly ushort _port;
		public Agent(string server, ushort port)
		{
			Id = Guid.NewGuid();
			_server = server;
			_port = port;
			_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_socket.Connect(server, port);
			GameState = new GameState();
			ConnectionListner = new ConnectionListner();
			OnRecive += ConnectionListner.ReciveListner;
			OnSend += ConnectionListner.SendListner;

			ConnectionListner.Subscribe(new SpawnPlayerHandler(this));
			ConnectionListner.Subscribe(new PlayerInfoHandler(this));
			ConnectionListner.Subscribe(new BlockChangeHandler(this));
			ConnectionListner.Subscribe(new ChatMessageHandler(this));
			ConnectionListner.Subscribe(new ChunkDataHandler(this));
			ConnectionListner.Subscribe(new PlayerPositionAndLookHandler(this));
			ConnectionListner.Subscribe(new EntityTeleportHandler(this));
			ConnectionListner.Subscribe(new EntityPositionHandler(this));
			ConnectionListner.Subscribe(new EntityPositionAndRotationHandler(this));
			ConnectionListner.Subscribe(new MultiBlockChangeHandler(this));
			ConnectionListner.Subscribe(new UnloadChunkHandler(this));
			ConnectionListner.Subscribe(new UpdateHealthHandler(this));
			ConnectionListner.Subscribe(new KeepAliveHandler(this));

			StartRecive();
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

		public Task Login(string nickname)
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
	}
}
