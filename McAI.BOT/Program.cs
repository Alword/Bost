using System;
using System.Threading.Tasks;

namespace McAI.BOT
{
    class Program
    {
        static void Main(string[] args)
        {
            Agent agent = new Agent("192.168.1.69", 25565);
            agent.OnRecive += Agent_OnRecive;
            Console.WriteLine("Hello World!");
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
            await agent.Login("Test");
        }

        private static void Agent_OnRecive(object sender, byte[] message)
        {
            Console.WriteLine(message);
        }
    }
}
