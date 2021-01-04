using Bost.Agent.Abstractions;
using System;
using System.Threading;

namespace Bost.Agent.Jobs
{
	public interface IAgentJob
	{
		/// <summary>
		///  Идентификатор работы
		/// </summary>
		public Guid Id { get; }
		public IAgent Agent { get; }
		public void Handle(CancellationToken cancellationToken);
		public void Unsubscribe(IJobCompleteHandler jobCompleteHandler);
		public void Subscribe(IJobCompleteHandler jobCompleteHandler);
	}
}