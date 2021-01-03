using Bost.Agent.AgentEventHandlers;
using Bost.Agent.Jobs;
using Bost.Agent.Model;
using Bost.Agent.State;
using Bost.Proto;
using Bost.Proto.Packet;
using Bost.Proto.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent
{
	public partial class Agent
	{
		private readonly Queue<IAgentJob> _jobs = new Queue<IAgentJob>();
		public void HandleJob(IAgentJob job)
		{
			_jobs.Enqueue(job);

			if (_jobs.Count == 1)
			{
				CancellationTokenSource source = new CancellationTokenSource();
				job.Handle(source.Token);
			}
		}
		public void CompleteJob(Agent agent)
		{
			_jobs.Dequeue();
			if (_jobs.Any())
			{
				var nextJob = _jobs.Peek();
				CancellationTokenSource source = new CancellationTokenSource();
				nextJob.Handle(source.Token);
			}
		}
	}
}
