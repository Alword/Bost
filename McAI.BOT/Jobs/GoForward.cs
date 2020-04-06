using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Serverbound;
using McAI.Proto.StreamReader.Abstractions;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace McAI.BOT.Jobs
{
    public class GoForward
    {
        private readonly Agent agent;
        public GoForward(Agent agent)
        {
            this.agent = agent;
        }

        public void Start(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(100);
                    agent.gameState.Bot.Position.Z += 0.5;
                    PlayerPositionPacket playerPositionPacket = new PlayerPositionPacket
                    {
                        X = agent.gameState.Bot.Position.X,
                        FeetY = agent.gameState.Bot.Position.Y,
                        OnGround = true,
                        Z = agent.gameState.Bot.Position.Z
                    };
                    await agent.Send(playerPositionPacket);
                }
            });
        }
    }
}
