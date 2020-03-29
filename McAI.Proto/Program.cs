using McAI.Proto.Commands;
using McAI.Proto.Commands.Client;
using McAI.Proto.Enum;
using McAI.Proto.Extentions;
using McAI.Proto.Model;
using McAI.Proxy;
using System;
using System.Collections.Generic;
using System.IO;

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

        static List<byte> queue = new List<byte>();
        static bool game = false;
        static bool handshake = true;
        private static void Proxy_OnSendMessage(object sender, byte[] message)
        {
            queue.AddRange(message);
            int compressedLength = 0;
            byte[] packetIdAnddata;
            while (queue.Count > 0)
            {
                var buffer = queue.ToArray();
                Varint.TryParse(buffer, out int numread, out int length);
                buffer = buffer[numread..(length + 1)];
                queue.RemoveRange(0, length + numread);

                if (game)
                {
                    Varint.TryParse(ref buffer, out compressedLength);
                }

                Varint.TryParse(ref buffer, out int packetId);

                if (commands.ContainsKey(packetId))
                {
                    if (handshake)
                    {
                        handshake = false;
                        new Handshake(true).Execute(buffer);
                    }
                    else
                    {
                        commands[packetId].Execute(buffer);
                    }
                }
                else
                {
                    string log = $"->{length}:{compressedLength}:[{packetId:X02}]:[{buffer.ToHexString()}]";
                    Log(log);
                }
            }
            game = true;
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
