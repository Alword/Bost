using Bost.Agent.Abstractions;
using System;
using System.Threading;

namespace Bost.Agent.Jobs
{
	public interface IAgentJob<T>
	{
		/// <summary>
		///  Идентификатор работы
		/// </summary>
		public Guid Id { get; }
		public IAgent Agent { get; }
		public void Handle(CancellationToken cancellationToken);
		public void Unsubscribe(IJobCompleteHandler<T> jobCompleteHandler);
		public void Subscribe(IJobCompleteHandler<T> jobCompleteHandler);
	}
}