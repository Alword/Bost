using Bost.BOT.Model.AStar;
using Bost.Proto.Packet.Play.Serverbound;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.BOT.Jobs
{
    public class Marshaller
    {
        private readonly Agent agent;
        private readonly List<PathNode> path;
        private static readonly double accuracy = 0.2;
        private static readonly double groundSpeed = 1;

        public Marshaller(Agent agent, List<PathNode> path)
        {
            this.agent = agent;
            this.path = path;
        }

        public void Start(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                var currentPosition = agent.gameState.Bot.Position;
                if (path == null)
                    return;
                foreach (var node in path)
                {
                    if (cancellationToken.IsCancellationRequested)
                        return;

                    currentPosition.X = node.Position.X + 0.5;
                    currentPosition.Y = node.Position.Y;
                    currentPosition.Z = node.Position.Z + 0.5;

                    PlayerPositionPacket playerPositionPacket = new PlayerPositionPacket
                    {
                        X = currentPosition.X,
                        FeetY = currentPosition.Y,
                        OnGround = true,
                        Z = currentPosition.Z
                    };
                    await agent.Send(playerPositionPacket);
                    await Task.Delay(50);
                }
            });
        }
    }
}
