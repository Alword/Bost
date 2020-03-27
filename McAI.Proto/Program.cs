using McAI.Proto.Commands;
using McAI.Proto.Enum;
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
        public static GameState GameState { get; set; }
        static void Main(string[] args)
        {
            GameState = new GameState();
            Log($"[Proto] Start session");
            var parser = new Parser();
            commands = parser.Commands;
            ProxyClient proxy = new ProxyClient("0.0.0.0", "95.139.206.185", 25565);
            proxy.Start();
            proxy.OnReciveMessage += Proxy_OnReciveMessage;
            proxy.OnSendMessage += Proxy_OnSendMessage;
            Console.ReadLine();
        }

        private static void Proxy_OnSendMessage(object sender, byte[] message)
        {

            int length = message[0].ReadVarInt();
            var packetId = message[1].ReadVarInt();
            var Data = message[2..length];
            string log = "";
            //if (code == 3)
            //    GameState.State = GameStates.Game;
            ////if (commands.ContainsKey(code))
            //{
            //    log = commands[code].Execute(message[1..]);
            //}
            //if (GameState.State == GameStates.Game)
            //{
            //    message = Ionic.Zlib.ZlibStream.UncompressBuffer(message);
            //}
            log = $"->:{length}:{packetId}:{Data.ToHexString()}";
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
