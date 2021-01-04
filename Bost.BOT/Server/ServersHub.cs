using Bost.Agent.GameState;
using System.Collections.Generic;

namespace Bost.Agent.Server
{
	public class ServersHub
	{
		private readonly Dictionary<string, SharedGameState> _serverGameState;
		public ServersHub()
		{
			_serverGameState = new Dictionary<string, SharedGameState>();
		}

		/// <summary>
		/// Get shared gamestate
		/// </summary>
		/// <param name="server">ip:port</param>
		/// <returns></returns>
		public SharedGameState Get(string server)
		{
			if (!_serverGameState.ContainsKey(server))
			{
				_serverGameState.Add(server, new SharedGameState());
			}
			return _serverGameState[server];
		}

		public SharedGameState Get(string ip, ushort port) => Get($"{ip}:{port}");

	}
}
