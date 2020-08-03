using McAI.Proto.Packet;
using McAI.Proto.StreamReader.Abstractions;
using System;
using System.Collections.Generic;

namespace McAI.Proto.StreamReader.Model
{
    public class GenericEventHub
    {
        private readonly Dictionary<Type, List<IPacketEvent>> eventHandlers;

        public GenericEventHub()
        {
            eventHandlers = new Dictionary<Type, List<IPacketEvent>>();
        }

        public void Subscribe<T>(IPacketEventHandler<T> packeteventHandeler) where T : BasePacket
        {
            var type = typeof(T);
            if (eventHandlers.ContainsKey(type))
            {
                eventHandlers[type].Add(packeteventHandeler);
            }
            else
            {
                eventHandlers.Add(type, new List<IPacketEvent>() { packeteventHandeler });
            }
        }

        public void Invoke(Type type, dynamic value)
        {
            if (eventHandlers.ContainsKey(type))
            {
                foreach (var h in eventHandlers[type])
                {
                    Convert.ChangeType(value, type);
                    h.OnPacket(value);
                }
            }
        }
    }
}
