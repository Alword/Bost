using McAI.Proto.StreamReader.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.StreamReader.Model
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
    }
}
