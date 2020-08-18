using Bost.Proto.Packet;
using Bost.Proto.StreamReader.Model;

namespace Bost.Proto.StreamReader.Abstractions
{
    public interface IPacketEventHandler
    {
        public void OnPacket(PacketKey type, BasePacket packet);
    }

    public interface IPacketEventHandler<T> : IPacketEvent where T : BasePacket
    {
        void OnPacket(T packet);
        void IPacketEvent.OnPacket(dynamic x) => OnPacket((T)x);
    }

    public interface IPacketEvent
    {
        void OnPacket(dynamic x);
    }
}
