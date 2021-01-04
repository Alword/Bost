using Bost.Agent.Abstractions;
using Bost.Agent.Enum;
using Bost.Agent.Extentions;
using Bost.Agent.Jobs;
using Bost.Agent.Model;
using Serilog;
using System.Diagnostics;

namespace Bost.Agent.Missions
{
	public class BlockMiningMission : BaseMission, IJobCompleteHandler<MiningJob>
	{
		private readonly Int3 _start;
		private readonly Int3 _end;
		private readonly MiningMode _mode;
		private Int3 current;
		private object currentLock = new object();
		private bool hasNextJob = true;
		public BlockMiningMission(Int3 start, Int3 end, MiningMode mode = MiningMode.Mine)
		{
			(_start, _end) = Сompare.MinMax(start, end);
			_mode = mode;
			current = _start;
		}

		public override bool SendJob(IAgent agent)
		{
			lock (currentLock)
			{
				if (!hasNextJob)
				{
					agent.AcceptMissions();
					return hasNextJob;
				}

				// closest block

				// pack job

				Int3 mineBlockPosition = current;
				Debug.WriteLine(mineBlockPosition);
				if (current.X < _end.X)
					current.X += 1;
				else if (current.Z < _end.Z)
				{
					current.X = _start.X;
					current.Z += 1;
				}
				else
				{
					hasNextJob = false;
				}
				var job = new MiningJob(agent, mineBlockPosition);
				job.Subscribe(this);
				// execute job
				job.Handle(default);
				return hasNextJob;
			}
		}

		public void OnComplete(IAgentJob<MiningJob> job)
		{
			job.Agent.AcceptMissions();
		}
	}
}
