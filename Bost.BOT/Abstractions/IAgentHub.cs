using System;
using System.Threading.Tasks;

namespace Bost.Agent.Model
{
	public interface IAgentHub
	{
		public Task<Agent> CreateAgent(string server, ushort port, string nickname);
		public Agent this[Guid key] { get; }
	}
}