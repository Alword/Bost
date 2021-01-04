using Bost.Agent.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Bost.Agent.Jobs
{
	public abstract class BaseAgentJob<T> : IAgentJob<T>, IJobCompleteHandler<T>
	{
		private readonly List<IJobCompleteHandler<T>> _subscribers = new List<IJobCompleteHandler<T>>();
		private readonly IAgent _agent;
		public Guid Id => Guid.NewGuid();
		public IAgent Agent => _agent;
		
		public BaseAgentJob(IAgent agent)
		{
			_agent = agent;
		}

		public virtual void Handle(CancellationToken cancellationToken)
		{
			OnComplete(this);
		}

		public virtual void Subscribe(IJobCompleteHandler<T> jobCompleteHandler)
		{
			_subscribers.Add(jobCompleteHandler);
		}

		public virtual void Unsubscribe(IJobCompleteHandler<T> jobCompleteHandler)
		{
			_subscribers.Remove(jobCompleteHandler);
		}

		public virtual void OnComplete(IAgentJob<T> job)
		{
			foreach (var sub in _subscribers.ToArray())
			{
				sub.OnComplete(this);
				job.Unsubscribe(this);
			}
		}
	}
}
