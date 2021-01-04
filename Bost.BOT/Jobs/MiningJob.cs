using Bost.Agent.Model;
using System.Threading;

namespace Bost.Agent.Jobs
{
	public class MiningJob : BaseAgentJob
	{
		private readonly Int3 _position;

		public MiningJob(IAgent agent, Int3 position) : base(agent)
		{
			_position = position;
		}

		public override void Handle(CancellationToken cancellationToken)
		{
			var reachTarget = new ReachTargetPointJob(Agent, _position, 1);
			reachTarget.Subscribe(this);
			reachTarget.Handle(cancellationToken);
		}

		public override void OnComplete(IAgentJob job)
		{
			if (job is ReachTargetPointJob)
			{
				var blockBreackJob = new BreakBlockJob(Agent, _position);
				blockBreackJob.Subscribe(this);
				blockBreackJob.Handle(default);
			}
			else if (job is BreakBlockJob)
			{
				base.OnComplete(job);
			}
		}
	}
}
