﻿using Bost.Proto.Packet;
using Bost.Proto.StreamReader.Abstractions;
using Bost.Proto.StreamReader.Enum;
using Bost.Proto.StreamReader.Model;

namespace Bost.Proto
{
	public class ConnectionListner
	{
		private McConnection read;
		private McConnection write;
		private readonly PacketEventHub packetEventHub;
		private readonly GenericEventHub genericEventHub;
		public ConnectionListner()
		{
			packetEventHub = new PacketEventHub();
			genericEventHub = new GenericEventHub();
			Reset();
		}
		public void Reset()
		{
			read = new McConnection(new McConnectionContext(packetEventHub, genericEventHub)
			{
				ConnectionState = ConnectionStates.Login,
				BoundTo = Bounds.Client
			});

			write = new McConnection(new McConnectionContext(packetEventHub, genericEventHub)
			{
				ConnectionState = ConnectionStates.Handshaking,
				BoundTo = Bounds.Server
			});
		}
		public void SendListner(object sender, byte[] array) => write.Listen(sender, array);
		public void ReciveListner(object sender, byte[] array) => read.Listen(sender, array);
		public void Subscribe(PacketKey t, IPacketEventHandler packetEventHandler) => packetEventHub.Subscribe(t, packetEventHandler);
		public void Subscribe<T>(IPacketEventHandler<T> packeteventHandeler)
			where T : BasePacket => genericEventHub.Subscribe(packeteventHandeler);


	}
}
