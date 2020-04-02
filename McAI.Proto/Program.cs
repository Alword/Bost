using McAI.Proto.Abstractions;
using McAI.Proto.Enum;
using McAI.Proto.Packet;
using McAI.Proto.StreamReader;
using McAI.Proto.StreamReader.Enum;
using McAI.Proto.StreamReader.Model;
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
        public static readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{DateTime.Now:yyyy-MM-dd-hh-mm-ss}-log.txt");
        public static GameState GameState { get; set; }
        static void Main(string[] args)
        {
            GameState = new GameState();
            Log($"[Proto] Start session");

            ConnectionListner connectionListner = new ConnectionListner();


            ProxyClient proxy = new ProxyClient("0.0.0.0", "95.139.138.186", 25565);
            proxy.Start();
            proxy.OnReciveMessage += connectionListner.ReciveListner;
            proxy.OnSendMessage += connectionListner.SendListner;

            Console.ReadLine();
        }

        public static void Log(string message)
        {
            //if (message.Contains("0x0E"))
            //{
            Console.WriteLine(message);
            //}
            //await File.AppendAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path), $"{message}{Environment.NewLine}");
        }
    }
}
