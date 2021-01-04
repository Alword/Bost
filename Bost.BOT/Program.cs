using System;
using System.Threading;

namespace Bost.Agent
{
	class Program
	{
		public static int CurrentProto = 754;
		static void Main(string[] args)
		{
			// rearrange chunk 
			Agent agent = new Agent("95.217.100.55", 25852, "NeAlword");
			
			CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

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
