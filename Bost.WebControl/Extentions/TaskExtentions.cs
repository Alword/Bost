using System;
using System.Threading.Tasks;

namespace Bost.WebControl.Extentions
{
	internal static class TaskExtentions
	{
		internal static async void FireAndForget(this Task task)
		{
			try
			{
				await task;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw e;
			}
		}
	}
}
