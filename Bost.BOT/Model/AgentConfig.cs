using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Agent.Model
{
	public class AgentConfig
	{
		public string Nickname { get; set; }
		public string ServerURI { get; set; }
		public ushort Port { get; set; }
	}
}
