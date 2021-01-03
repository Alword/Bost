using Bost.Agent.Abstractions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Jobs
{
	public class BaseAgentJob : IAgentJob, IJobCompleteHandler
	{
		private readonly List<IJobCompleteHandler> _subscribers = new List<IJobCompleteHandler>();
		private readonly Agent _agent;
		public Guid Id => Guid.NewGuid();
		public BaseAgentJob(Agent agent)
		{
			_agent = agent;
		}
		public Agent Agent => _agent;

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
