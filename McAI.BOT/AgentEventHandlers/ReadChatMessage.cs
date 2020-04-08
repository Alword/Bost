using McAI.BOT.Model.AStar;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Abstractions;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.AgentEventHandlers
{
    public class ReadChatMessage : BaseAgentEvent
    {
        public ReadChatMessage(Agent agent) : base(agent)
        {
        }

        public override void OnPacket(PacketKey type, BasePacket packet)
        {
            var chatMessagePacket = (ChatMessagePacket)packet;
            var chat = chatMessagePacket.Chat;

            var name = chat.GetSenderName();
            var text = chat.GetText();

            if (text == "сюда")
            {
                Pathfinder pathfinder = new Pathfinder(agent.gameState.World, PathFinderConfig.Default);
                //pathfinder.FindPath(agent.gameState.Bot.Position)
            }
        }
    }
}
