using McAI.BOT.AgentEventHandlers;
using McAI.Proto;
using McAI.Proto.StreamReader.Enum;
using McAI.Proto.StreamReader.Model;
using System;
using System.Threading.Tasks;

namespace McAI.BOT
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionListner connectionListner = new ConnectionListner();
            Agent agent = new Agent("192.168.1.69", 25565);
            agent.OnRecive += connectionListner.ReciveListner;
            agent.OnSend += connectionListner.SendListner;
            connectionListner.Subscribe(new PacketKey(0x21, ConnectionStates.Play, Bounds.Client), new KeepAlive(agent));

            Run(agent).GetAwaiter().GetResult();

            while (true)
            {
                ConsoleKeyInfo e = Console.ReadKey();
                if (e.Key == ConsoleKey.Escape)
                    break;
            }
        }

        public static async Task Run(Agent agent)
        {
            await agent.Login("NeAlword");

        }
    }
}
