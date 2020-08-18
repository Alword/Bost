using Bost.Proto.Packet;
using Bost.Proto.StreamReader.Abstractions;
using System.Collections.Generic;

namespace Bost.Proto.StreamReader.Model
{
    public class PacketEventHub
    {
        Dictionary<PacketKey, List<IPacketEventHandler>> eventHandlers;

        public PacketEventHub()
        {
            eventHandlers = new Dictionary<PacketKey, List<IPacketEventHandler>>();
        }

        public void Subscribe(PacketKey state, IPacketEventHandler packetEventHandler)
        {
            if (eventHandlers.ContainsKey(state))
            {
                eventHandlers[state].Add(packetEventHandler);
            }
            else
            {
                List<IPacketEventHandler> handlers = new List<IPacketEventHandler>
                {
                    packetEventHandler
                };
                eventHandlers.Add(state, handlers);
            }
        }

        public void Invoke(PacketKey packetKey, BasePacket basePacket)
        {
            if (eventHandlers.ContainsKey(packetKey))
            {
                foreach (var h in eventHandlers[packetKey])
                {
                    h.OnPacket(packetKey, basePacket);
                }
            }
        }
    }
}
