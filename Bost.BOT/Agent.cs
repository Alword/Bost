using Bost.Agent.GameState;
using Bost.Agent.Model;
using Bost.Agent.PacketHandlers.Clientbound;
using Bost.Agent.PacketHandlers.Serverbound;
using Bost.Agent.Types;
using Bost.Proto;
using System;
using System.Threading;

namespace Bost.Agent
{
	public partial class Agent : MinecraftJavaAgent, IAgent
	{
		public readonly SharedGameState SharedState;
		public readonly ConnectionListner ConnectionListner;
		public readonly CancellationToken CancellationToken;
		public Guid Id { get; }
		public Double3 Position { get; set; }
		public World World => SharedState.World;

		public Agent(string server, ushort port, string nickname, SharedGameState shared = null)
			: base(server, port, nickname)
		{
			Id = Guid.NewGuid();
			SharedState = shared ?? new SharedGameState();
			ConnectionListner = new ConnectionListner();
			OnRecive += ConnectionListner.ReciveListner;
			OnSend += ConnectionListner.SendListner;
			Reset += (e, x) => ConnectionListner.Reset();
			
			// clientbound
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
			ConnectionListner.Subscribe(new ChatMessageHandler(this));

			// serverbound
			ConnectionListner.Subscribe(new PlayerPositionPacketHandler(this));

			AcceptMissions();
		}

		public void AcceptMissions()
		{
			SharedState.Missions.Attach(this);
		}
	}
}
