using Bost.Agent.Events;
using Bost.Agent.Model;
using Bost.Agent.Types;
using Bost.Proto.Packet;
using System;
using System.Threading.Tasks;

namespace Bost.Agent
{
	public interface IAgent
	{
		Guid Id { get; }
		Double3 Position { get; }
		World World { get; }
		void SubscribeOnBlockChanged(IBlockChangedEventHandler handler);
		Task Send<T>(T basePacket) where T : BasePacket;
		void AcceptMissions();
	}
}
