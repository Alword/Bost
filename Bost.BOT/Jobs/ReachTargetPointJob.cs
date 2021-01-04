using Bost.Agent.Model.AStar;
using Bost.Agent.Types;
using Bost.Proto.Packet.Play.Serverbound;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Jobs
{
	public class ReachTargetPointJob : BaseAgentJob
	{
		private readonly Double3 _to;
		private readonly int _skipFromEnd;

		public ReachTargetPointJob(IAgent agent, Double3 to, int skipFromEnd = 0) : base(agent)
		{
			_to = to;
			_skipFromEnd = skipFromEnd;
		}

		public override async void Handle(CancellationToken cancellationToken)
		{
			var path = PathFromAgent(Agent);

			if (path == null) return;

			foreach (var node in path[..^_skipFromEnd])
			{
				if (cancellationToken.IsCancellationRequested) return;

				var nextPossition = new Double3(node.Position.X + 0.5, node.Position.Y, node.Position.Z + 0.5);

				PlayerPositionPacket playerPositionPacket = new PlayerPositionPacket
				{
					X = nextPossition.X,
					FeetY = nextPossition.Y + 1,
					OnGround = true,
					Z = nextPossition.Z
				};
				await Agent.Send(playerPositionPacket);
				await Task.Delay(50);
			}

			OnComplete(this);
		}

		private PathNode[] PathFromAgent(IAgent agent)
		{
			using Pathfinder pathfinder = new Pathfinder(agent.World, PathFinderConfig.Default);

			Double3 from = agent.Position;

			return pathfinder.FindPath(from, _to).ToArray();
		}
	}
}
