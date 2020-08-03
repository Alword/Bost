using McAI.BOT.Jobs;
using McAI.BOT.Model.AStar;
using McAI.BOT.Types;
using McAI.Proto.Packet;
using McAI.Proto.StreamReader.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace McAI.BOT.AgentEventHandlers
{
    public class ChatMessageHandler : BaseAgentEventHandler<Proto.Packet.Play.Clientbound.ChatMessagePacket>
    {
        public ChatMessageHandler(Agent agent) : base(agent) { }

        public override void OnPacket(Proto.Packet.Play.Clientbound.ChatMessagePacket chatMessagePacket)
        {
            Task.Run(() =>
            {
                var chat = chatMessagePacket.Chat;

                var name = chat.GetSenderName();
                var text = chat.GetText();

                if (text.Contains("сюда", StringComparison.InvariantCultureIgnoreCase))
                {
                    using Pathfinder pathfinder = new Pathfinder(agent.gameState.World, PathFinderConfig.Default);

                    var startPosition = agent.gameState.Bot.Position;
                    var endPosition = agent.gameState.Players.ContainsNick(name).Position;

                    Double3 from = new Double3(startPosition.X, startPosition.Y, startPosition.Z);
                    Double3 to = new Double3(endPosition.X, endPosition.Y, endPosition.Z);

                    var path = pathfinder.FindPath(from, to);

                    Marshaller marshaller = new Marshaller(agent, path.Take(path.Count - 2).ToList());
                    marshaller.Start(default);

                }
            });
        }
    }
}
