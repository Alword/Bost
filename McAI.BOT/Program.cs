using McAI.BOT.AgentEventHandlers;
using McAI.Proto;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Enum;
using McAI.Proto.StreamReader.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace McAI.BOT
{
    class Program
    {
        static void Main(string[] args)
        {
            // rearrange chunk 
            ConnectionListner connectionListner = new ConnectionListner();
            Agent agent = new Agent("192.168.1.69", 25565);
            agent.OnRecive += connectionListner.ReciveListner;
            agent.OnSend += connectionListner.SendListner;

            connectionListner.Subscribe(new BlockChangeHandler(agent));
            connectionListner.Subscribe(new ChatMessageHandler(agent));
            connectionListner.Subscribe(new ChunkDataHandler(agent));
            connectionListner.Subscribe(new EntityPositionAndRotationHandler(agent));
            connectionListner.Subscribe(new EntityPositionHandler(agent));
            connectionListner.Subscribe(new EntityTeleportHandler(agent));
            connectionListner.Subscribe(new KeepAliveHandler(agent));
            connectionListner.Subscribe(new MultiBlockChangeHandler(agent));
            connectionListner.Subscribe(new PlayerInfoHandler(agent));
            connectionListner.Subscribe(new PlayerPositionAndLookHandler(agent));
            connectionListner.Subscribe(new SpawnPlayerHandler(agent));
            connectionListner.Subscribe(new UnloadChunkHandler(agent));
            connectionListner.Subscribe(new UpdateHealthHandler(agent));

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

            // GoForward goForward = new GoForward(agent);
            // goForward.Start(cancelTokenSource.Token);

            Run(agent).GetAwaiter().GetResult();
            while (true)
            {
                ConsoleKeyInfo e = Console.ReadKey();
                if (e.Key == ConsoleKey.Escape)
                    break;
                if (e.Key == ConsoleKey.S)
                    cancelTokenSource.Cancel();
            }
        }

        public static async Task Run(Agent agent)
        {
            await agent.Login("NeAlword");

        }
    }
}
