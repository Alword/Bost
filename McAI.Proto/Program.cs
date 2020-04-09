using McAI.Proxy;
using System;
using System.IO;

namespace McAI.Proto
{
    class Program
    {
        public static readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{DateTime.Now:yyyy-MM-dd-hh-mm-ss}-log.txt");
        static void Main(string[] args)
        {
            Log($"[Proto] Start session");

            ConnectionListner connectionListner = new ConnectionListner();

            ProxyClient proxy = new ProxyClient("0.0.0.0", "94.28.222.30", 25565);
            proxy.Start();
            proxy.OnReciveMessage += connectionListner.ReciveListner;
            proxy.OnSendMessage += connectionListner.SendListner;

            Console.ReadLine();
        }

        public static void Log(string message)
        {
            if ((message.Contains("0x0A") && message.Contains("Client")))
            {
                Console.WriteLine(message);
            }
            //await File.AppendAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path), $"{message}{Environment.NewLine}");
        }
    }
}
