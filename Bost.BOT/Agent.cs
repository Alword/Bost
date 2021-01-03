using Bost.Agent.AgentEventHandlers;
using Bost.Agent.State;
using Bost.Proto;
using Bost.Proto.Packet;
using Bost.Proto.Types;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent
{
	public partial class Agent
	{
		private readonly string _server;
		private readonly ushort _port;
		private readonly string _nickname;
		private readonly Queue<byte[]> _commandQueue;

		public readonly GameState GameState;
		public readonly ConnectionListner ConnectionListner;
		public readonly CancellationToken CancellationToken;

		public Guid Id { get; }

		public delegate void MessageHandler(object sender, byte[] message);
		public event MessageHandler OnRecive;
		public event MessageHandler OnSend;
		public Agent(string server, ushort port, string nickname)
		{
			Id = Guid.NewGuid();
			_server = server;
			_port = port;
			_nickname = nickname;
			_commandQueue = new Queue<byte[]>();
			CancellationToken = new CancellationToken();
			GameState = new GameState();
			ConnectionListner = new ConnectionListner();
			OnRecive += ConnectionListner.ReciveListner;
			OnSend += ConnectionListner.SendListner;
			ConnectionListner.Subscribe(new SpawnPlayerHandler(this));
			ConnectionListner.Subscribe(new PlayerInfoHandler(this));
			ConnectionListner.Subscribe(new BlockChangeHandler(this));
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

		public async Task Send(BasePacket basePacket)
		{
			List<byte> toSend = new List<byte>();
			Write(basePacket, true, toSend);
			await Send(toSend.ToArray());
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
	}
}
