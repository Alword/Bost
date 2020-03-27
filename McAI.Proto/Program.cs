using McAI.Proto.Commands;
using McAI.Proto.Extentions;
using McAI.Proxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace McAI.Proto
{
    class Program
    {
        private static Dictionary<int, Command> commands;
        public static readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{DateTime.Now:yyyy-MM-dd-hh-mm-ss}-log.txt");
        static void Main(string[] args)
        {
            Log($"[Proto] Start session");
            var parser = new Parser();
            commands = parser.Commands;
            ProxyClient proxy = new ProxyClient("0.0.0.0", "95.139.206.185", 25565);
            proxy.Start();
            proxy.OnReciveMessage += Proxy_OnReciveMessage;
            proxy.OnSendMessage += Proxy_OnSendMessage;
            Console.ReadLine();
        }

        private static async void Proxy_OnSendMessage(object sender, byte[] message)
        {
            string log = "";
            int code = message[0];
            if (commands.ContainsKey(code))
            {
                log = commands[code].Execute(message[1..]);
            }
            else
            {
                log = $"->:{code}:{message.ToHexString()}";
            }
            Log(log);
        }

        private static void Proxy_OnReciveMessage(object sender, byte[] message)
        {
            //throw new NotImplementedException();
        }

        public static async void Log(string message)
        {
            Console.WriteLine(message);
            await File.AppendAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path), $"{message}{Environment.NewLine}");
        }
    }
}
