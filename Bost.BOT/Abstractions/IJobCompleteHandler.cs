using Bost.Agent.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Agent.Abstractions
{
	public interface IJobCompleteHandler
	{
		void OnComplete(IAgentJob job);
	}
}
