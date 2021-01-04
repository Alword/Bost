using Bost.Agent.Missions;
using System;
using System.Threading.Tasks;

namespace Bost.Agent.Model
{
	public interface IAgentHub
	{
		Task<Agent> CreateAgent(string server, ushort port, string nickname);
		Agent this[Guid key] { get; }

		/// <summary>
		/// Send mission to server
		/// </summary>
		/// <param name="server">ip:port</param>
		/// <param name="BaseMission">mission</param>
		void SubmitMission(string server, BaseMission baseMission);
	}
}