using McAI.Proto.Packet;
using McAI.Proto.StreamReader.Abstractions;

namespace McAI.BOT.AgentEventHandlers
{
    public abstract class BaseAgentEventHandler<T> : IPacketEventHandler<T> where T : BasePacket
    {
        protected readonly Agent agent;
        public BaseAgentEventHandler(Agent agent)
        {
            this.agent = agent;
        }
        public abstract void OnPacket(T packet);
    }
}
