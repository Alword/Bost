using McAI.Proto.Packet;
using McAI.Proto.StreamReader.Model;

namespace McAI.Proto.StreamReader.Abstractions
{
    public interface IPacketEventHandler
    {
        public void OnPacket(PacketKey type, BasePacket packet);
    }

    public abstract class PacketEventHandler<T> : IPacketEvent where T : BasePacket
    {
        public abstract void OnPacket(T packet);
        public void OnPacket(dynamic x) => OnPacket((T)x);
    }

    public interface IPacketEvent
    {
        public void OnPacket(dynamic x);
    }
}
