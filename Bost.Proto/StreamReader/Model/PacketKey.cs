using Bost.Proto.StreamReader.Enum;
using System;

namespace Bost.Proto.StreamReader.Model
{
	public struct PacketKey
	{
		public int PacketId;
		public ConnectionStates ConnectionState;
		public Bounds Bound;

		public PacketKey(int packetId, ConnectionStates connectionState, Bounds bounds)
		{
			this.PacketId = packetId;
			this.ConnectionState = connectionState;
			this.Bound = bounds;
		}

		public override bool Equals(object obj)
		{
			return obj is PacketKey key &&
				   PacketId == key.PacketId &&
				   ConnectionState == key.ConnectionState &&
				   Bound == key.Bound;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(PacketId, ConnectionState, Bound);
		}
	}
}
