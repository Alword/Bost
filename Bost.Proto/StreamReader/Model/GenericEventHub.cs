﻿using Bost.Proto.Packet;
using Bost.Proto.StreamReader.Abstractions;
using System;
using System.Collections.Generic;

namespace Bost.Proto.StreamReader.Model
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
					h.OnPacket(value);
				}
			}
		}
	}
}
