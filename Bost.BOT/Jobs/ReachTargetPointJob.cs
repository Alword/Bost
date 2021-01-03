using Bost.Agent.Model.AStar;
using Bost.Agent.Types;
using Bost.Proto.Packet.Play.Serverbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Jobs
{
	public class ReachTargetPointJob : BaseAgentJob
	{
		private readonly Double3 _to;
		private readonly int _skipFromEnd;

		public ReachTargetPointJob(Agent agent, Double3 to, int skipFromEnd = 0) : base(agent)
		{
			_to = to;
			_skipFromEnd = skipFromEnd;
		}

		public override async void Handle(CancellationToken cancellationToken)
		{
			var path = PathFromAgent(Agent);
			var currentPosition = Agent.GameState.Bot.Position;

			if (path == null) return;

			foreach (var node in path[..^_skipFromEnd])
			{
				if (cancellationToken.IsCancellationRequested) return;

				currentPosition.X = node.Position.X + 0.5;
				currentPosition.Y = node.Position.Y;
				currentPosition.Z = node.Position.Z + 0.5;

				PlayerPositionPacket playerPositionPacket = new PlayerPositionPacket
				{
					X = currentPosition.X,
					FeetY = currentPosition.Y + 1,
					OnGround = true,
					Z = currentPosition.Z
				};
				await Agent.Send(playerPositionPacket);
				await Task.Delay(50);
			}

			OnComplete(this);
		}

		private PathNode[] PathFromAgent(Agent agent)
		{
			using Pathfinder pathfinder = new Pathfinder(agent.World, PathFinderConfig.Default);

			var startPosition = agent.GameState.Bot.Position;

			Double3 from = new Double3(startPosition.X, startPosition.Y, startPosition.Z);

			return pathfinder.FindPath(from, _to).ToArray();
		}
	}
}
