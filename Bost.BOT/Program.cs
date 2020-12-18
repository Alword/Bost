using Bost.Agent.AgentEventHandlers;
using Bost.Proto;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent
{
	class Program
	{
		public static int CurrentProto = 754;
		static void Main(string[] args)
		{
			// rearrange chunk 
			Agent agent = new Agent("95.217.100.55", 25852);

			CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

			Task.Run(async () =>
			{
				await agent.Login("NeAlword");
			}).GetAwaiter().GetResult();

			while (true)
			{
				ConsoleKeyInfo e = Console.ReadKey();
				if (e.Key == ConsoleKey.Escape)
					break;
				if (e.Key == ConsoleKey.S)
					cancelTokenSource.Cancel();
			}
		}
	}
}
