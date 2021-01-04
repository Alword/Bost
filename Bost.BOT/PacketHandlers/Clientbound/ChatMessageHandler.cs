using Bost.Proto.Packet.Play.Clientbound;

namespace Bost.Agent.PacketHandlers.Clientbound
{
	public class ChatMessageHandler : BaseAgentEventHandler<ChatMessagePacket>
	{
		public ChatMessageHandler(Agent agent) : base(agent)
		{
		}

		public override async void OnPacket(ChatMessagePacket data)
		{
			if (data.Chat.GetText().Contains("/login [пароль]!"))
			{
				var chanMessagePacket = new Proto.Packet.Play.Serverbound.ChatMessagePacket()
				{
					Message = "/login 123456"
				};
				await agent.Send(chanMessagePacket);
			}
			else if (data.Chat.GetText().Contains("/register"))
			{
				var chanMessagePacket = new Proto.Packet.Play.Serverbound.ChatMessagePacket()
				{
					Message = "/register 123456"
				};
				await agent.Send(chanMessagePacket);
			};
		}
	}
}
