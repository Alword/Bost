using Bost.Proxy;
using System;

namespace Bost.Proto
{
	class Program
	{
		static void Main(string[] args)
		{
			Log($"[Proto] Start session");

			ConnectionListner connectionListner = new ConnectionListner();

			ProxyClient proxy = new ProxyClient("0.0.0.0", "95.217.100.55", 25852);
			proxy.Start();
			proxy.OnReciveMessage += connectionListner.ReciveListner;
			proxy.OnSendMessage += connectionListner.SendListner;

			Console.ReadLine();
		}

		public static void Log(string message)
		{
			Console.WriteLine(message);
		}
	}
}