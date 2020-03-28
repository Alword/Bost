using McAI.Proto.Commands;
using McAI.Proto.Enum;
using McAI.Proto.Extentions;
using McAI.Proto.Model;
using McAI.Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        static byte[] queue = new byte[2048];

        private static void Proxy_OnSendMessage(object sender, byte[] message)
        {
            int index = 0;
            Array.Copy(message, 0, queue, index, message.Length);

            while (true)
            {
                if (index >= message.Length)
                {
                    index = 0;
                    break;
                };

                var isLength = Varint.TryParse(queue[index..], out int numread, out int length);
                index += numread;
                var isCompressed = Varint.TryParse(queue[index..], out numread, out int compressedLength);
                index += numread;


                var zlibData = queue[(index)..(index + length - numread)];
                Varint.TryParse(zlibData, out int read, out int compression);
                index += length - numread;
                Varint.TryParse(zlibData, out read, out int packetId);
                string log = $"->{length}:{compressedLength}:[{packetId:X02}]:[{zlibData[read..].ToHexString()}]";
                Log(log);
            }
        }

        private static void Proxy_OnReciveMessage(object sender, byte[] message)
        {
            //int length = message[0].ReadVarInt();
            //int messageLength = message.Length;
            //var packetId = message[1].ReadVarInt();
            //var Data = message[2..length];

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
            //log = $"<-:{message[0]}:{message[1..].ToHexString()}";
            //Console.WriteLine(log);
            //Log(log);
        }

        public static async void Log(string message)
        {
            Console.WriteLine(message);
            //await File.AppendAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path), $"{message}{Environment.NewLine}");
        }
    }
}
