using Bost.Agent.Jobs;

namespace Bost.Agent.Abstractions
{
	public interface IJobCompleteHandler<T>
	{
		void OnComplete(IAgentJob<T> job);
	}
}
