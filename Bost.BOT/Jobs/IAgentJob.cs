using Bost.Agent.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Jobs
{
	public interface IAgentJob
	{
		/// <summary>
		///  Идентификатор работы
		/// </summary>
		public Guid Id { get; }
		public Agent Agent { get; }
		public void Handle(CancellationToken cancellationToken);
		public void Unsubscribe(IJobCompleteHandler jobCompleteHandler);
		public void Subscribe(IJobCompleteHandler jobCompleteHandler);
	}
}