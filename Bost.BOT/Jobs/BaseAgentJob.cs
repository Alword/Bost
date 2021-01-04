using Bost.Agent.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Bost.Agent.Jobs
{
	public class BaseAgentJob : IAgentJob, IJobCompleteHandler
	{
		private readonly List<IJobCompleteHandler> _subscribers = new List<IJobCompleteHandler>();
		private readonly IAgent _agent;
		public Guid Id => Guid.NewGuid();
		public BaseAgentJob(IAgent agent)
		{
			_agent = agent;
		}
		public IAgent Agent => _agent;

		public virtual void Handle(CancellationToken cancellationToken)
		{
			OnComplete(this);
		}

		public virtual void Subscribe(IJobCompleteHandler jobCompleteHandler)
		{
			_subscribers.Add(jobCompleteHandler);
		}

		public virtual void Unsubscribe(IJobCompleteHandler jobCompleteHandler)
		{
			_subscribers.Remove(jobCompleteHandler);
		}

		public virtual void OnComplete(IAgentJob job)
		{
			foreach (var sub in _subscribers.ToArray())
			{
				sub.OnComplete(this);
				job.Unsubscribe(this);
			}
		}
	}
}
