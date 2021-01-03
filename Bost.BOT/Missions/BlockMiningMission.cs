using Bost.Agent.Abstractions;
using Bost.Agent.Enum;
using Bost.Agent.Jobs;
using Bost.Agent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Agent.Missions
{
	public class BlockMiningMission : BaseMission
	{
		private readonly Int3 _start;
		private readonly Int3 _end;
		private readonly MiningMode _mode;

		public BlockMiningMission(Int3 start, Int3 end, MiningMode mode = MiningMode.Mine)
		{
			_start = start;
			_end = end;
			_mode = mode;
		}
		public override void HandleJob(Agent agent)
		{
			// closest block

			// pack job
			var job = new MiningJob(agent, _start);

			// execute job
			job.Handle(default);
		}
	}
}
