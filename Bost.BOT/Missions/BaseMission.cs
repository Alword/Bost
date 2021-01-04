using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Agent.Missions
{
	public abstract class BaseMission
	{
		public BaseMission()
		{
		}

		public abstract void SendJob(IAgent agent);
	}
}
