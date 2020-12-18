using System;
using System.Threading.Tasks;

namespace Bost.Agent.Model
{
	public interface IAgentHub
	{
		public Task<Agent> CreateAgent(string server, ushort port);
		public Agent this[Guid key] { get; }
	}
}