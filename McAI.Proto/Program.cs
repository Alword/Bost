using McAI.Proxy;
using System;

namespace McAI.Proto
{
    class Program
    {
        static void Main(string[] args)
        {
            Log($"[Proto] Start session");

            ConnectionListner connectionListner = new ConnectionListner();

            ProxyClient proxy = new ProxyClient("0.0.0.0", "94.28.213.8", 25565);
            proxy.Start();
            proxy.OnReciveMessage += connectionListner.ReciveListner;
            proxy.OnSendMessage += connectionListner.SendListner;

            Console.ReadLine();
        }

        public static void Log(string message)
        {
            if ((message.Contains("0x11") && message.Contains("Server")))
            {
                Console.WriteLine(message);
            }
        }
    }
}