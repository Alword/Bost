using McAI.Proto.Packet;
using McAI.Proto.StreamReader.Abstractions;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.AgentEventHandlers
{
    public abstract class BaseAgentEvent : IPacketEventHandler
    {
        protected readonly Agent agent;
        public BaseAgentEvent(Agent agent)
        {
            this.agent = agent;
        }

        public abstract void OnPacket(PacketKey type, BasePacket packet);
    }
}
