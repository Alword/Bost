using Bost.Agent.Abstractions;
using Bost.Agent.Enum;
using Bost.Agent.Extentions;
using Bost.Agent.Jobs;
using Bost.Agent.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		private Int3 current;
		private object currentLock = new object();
		public BlockMiningMission(Int3 start, Int3 end, MiningMode mode = MiningMode.Mine)
		{
			(_start, _end) = Сompare.MinMax(start, end);
			_mode = mode;
			current = _start;
		}

		public override void SendJob(IAgent agent)
		{
			// closest block

			// pack job

			lock (currentLock)
			{
				Int3 mineBlockPosition = current;
				Debug.WriteLine(mineBlockPosition);
				if (current.X < _end.X)
					current.X += 1;
				else if (current.Z < _end.Z)
				{
					current.X = _start.X;
					current.Z += 1;
				}
				var job = new MiningJob(agent, mineBlockPosition);

				// execute job
				job.Handle(default);
			}


		}
	}
}
