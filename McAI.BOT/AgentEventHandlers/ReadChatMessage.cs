using McAI.BOT.Jobs;
using McAI.BOT.Model.AStar;
using McAI.BOT.Types;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.Packet.Play.Serverbound;
using McAI.Proto.StreamReader.Abstractions;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McAI.BOT.AgentEventHandlers
{
    public class ReadChatMessage : BaseAgentEvent
    {
        public ReadChatMessage(Agent agent) : base(agent)
        {
        }

        public override void OnPacket(PacketKey type, BasePacket packet)
        {
            Task.Run(() =>
            {

                var chatMessagePacket = (Proto.Packet.Play.Clientbound.ChatMessagePacket)packet;
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
                    Marshaller marshaller = new Marshaller(agent, path);
                    marshaller.Start(default);
                }
            });
        }
    }
}
