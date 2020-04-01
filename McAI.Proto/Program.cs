using McAI.Proto.Abstractions;
using McAI.Proto.Enum;
using McAI.Proto.Packet;
using McAI.Proto.StreamReader;
using McAI.Proto.StreamReader.Commands;
using McAI.Proto.StreamReader.Enum;
using McAI.Proxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace McAI.Proto
{
    class Program
    {
        private static BaseMcStream SendMessage;
        private static BaseMcStream ReciveMessage;
        public static readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{DateTime.Now:yyyy-MM-dd-hh-mm-ss}-log.txt");
        public static GameState GameState { get; set; }
        static void Main(string[] args)
        {
            GameState = new GameState();
            Log($"[Proto] Start session");
            SendMessage = InitializeSend(GameState);
            ReciveMessage = InitializeRecive(GameState);

            ProxyClient proxy = new ProxyClient("0.0.0.0", "95.139.138.186", 25565);
            proxy.Start();
            proxy.OnReciveMessage += Proxy_OnReciveMessage;
            proxy.OnSendMessage += Proxy_OnSendMessage;

            Console.ReadLine();
        }

        private static void Proxy_OnSendMessage(object sender, byte[] message)
        {
            SendMessage.Read(message);
        }

        private static void Proxy_OnReciveMessage(object sender, byte[] message)
        {
            ReciveMessage.Read(message);
        }

        public static BaseMcStream InitializeRecive(GameState gameState)
        {
            return new BaseMcStream(new Dictionary<GameStates, ICommand<int, byte[]>>()
            {
                {GameStates.Login, new ToClientUncompressedStream(gameState)},
                {GameStates.Game, new ToClientCompressedStream(gameState)}
            }, () => { return gameState.ServerState; });
        }

        public static BaseMcStream InitializeSend(GameState gameState)
        {
            return new BaseMcStream(new Dictionary<GameStates, ICommand<int, byte[]>>()
            {
                {GameStates.Login, new ToServerUncompressedStream(gameState)},
                {GameStates.Game, new ToServerCompressedStream(gameState)}
            }, () => { return gameState.ClientState; });
        }

        public static void Log(string message)
        {
            Console.WriteLine(message);
            //await File.AppendAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path), $"{message}{Environment.NewLine}");
        }
    }
}
