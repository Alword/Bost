using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Deductions.Model
{
	public class AgentContext
	{
		private readonly Dictionary<string, int> _state;
		public AgentContext()
		{
			_state = new Dictionary<string, int>();
		}
		public int HasState(string stateName)
		{
			var count = _state.ContainsKey(stateName);
			return _state[stateName];
		}
	}
}
