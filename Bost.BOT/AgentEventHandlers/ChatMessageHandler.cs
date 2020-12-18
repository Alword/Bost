using Bost.Agent.Jobs;
using Bost.Agent.Model.AStar;
using Bost.Agent.Types;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bost.Agent.AgentEventHandlers
{
	public class ChatMessageHandler : BaseAgentEventHandler<Proto.Packet.Play.Clientbound.ChatMessagePacket>
	{
		public ChatMessageHandler(Agent agent) : base(agent) { }

		public override void OnPacket(Proto.Packet.Play.Clientbound.ChatMessagePacket chatMessagePacket)
		{
			Console.WriteLine(chatMessagePacket.Chat);
			Task.Run(() =>
			{
				Proto.Model.ChatObject.Chat chat = chatMessagePacket.Chat;
				var text = chat.GetText();
				if (text.Contains("сюда", StringComparison.InvariantCultureIgnoreCase))
				{
					using Pathfinder pathfinder = new Pathfinder(agent.GameState.World, PathFinderConfig.Default);

					var startPosition = agent.GameState.Bot.Position;
					var endPosition = agent.GameState.Players.ContainsNick("Dalores").Position;

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
