using McAI.Proxy;
using System;
using System.IO;
using System.Threading.Tasks;

namespace McAI.Proto
{
    class Program
    {
        public static readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{DateTime.Now:yyyy-MM-dd-hh-mm-ss}-log.txt");
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

            if (!message.StartsWith("0")
                && !(message.Contains("1x3C") && message.Contains("Client"))
                && !(message.Contains("1x46") && message.Contains("Client"))
                && !(message.Contains("1x4F") && message.Contains("Client"))
                && !(message.Contains("1x25") && message.Contains("Client"))
                && !(message.Contains("1x3C") && message.Contains("Client")))
            {
                Console.WriteLine(message);
            }
            //await File.AppendAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path), $"{message}{Environment.NewLine}");
        }
    }
}
