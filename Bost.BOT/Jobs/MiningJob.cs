using Bost.Agent.Abstractions;
using Bost.Agent.Model;
using Serilog;
using System.Threading;

namespace Bost.Agent.Jobs
{
	public class MiningJob : BaseAgentJob<MiningJob>, IJobCompleteHandler<ReachTargetPointJob>, IJobCompleteHandler<BreakBlockJob>
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

		public void OnComplete(IAgentJob<ReachTargetPointJob> job)
		{
			var blockBreackJob = new BreakBlockJob(Agent, _position);
			blockBreackJob.Subscribe(this);
			blockBreackJob.Handle(default);
		}

		public void OnComplete(IAgentJob<BreakBlockJob> job)
		{
			OnComplete(this);
		}
	}
}
