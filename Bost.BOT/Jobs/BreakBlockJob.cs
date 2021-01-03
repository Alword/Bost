using Bost.Agent.Events;
using Bost.Agent.Model;
using Bost.Proto.Packet.Play.Serverbound;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Jobs
{
	public class BreakBlockJob : BaseAgentJob, IBlockChangedEventHandler
	{
		private static readonly int _swingDelay = 250;
		private readonly Int3 _blockPosition;
		private CancellationTokenSource swingHandTokenSource = new CancellationTokenSource();
		public BreakBlockJob(Agent agent, Int3 blockPosition) : base(agent)
		{
			_blockPosition = blockPosition;
		}

		public override async void Handle(CancellationToken cancellationToken)
		{
			if (Agent.DistanceTo(_blockPosition) > 6) return;

			// subscribe block change
			Agent.SubscribeOnBlockChanged(this);

			// start hand work
			SwingHand(Agent, cancellationToken, swingHandTokenSource.Token);

			// start digging
			PlayerDiggingPacket playerDigging = new PlayerDiggingPacket()
			{
				Face = Proto.Enum.Face.Bottom,
				Location = _blockPosition,
				Status = Proto.Enum.PlayerDiggingStatus.StartedDigging
			};
			await Agent.Send(playerDigging);

			// send block end diggign
			playerDigging.Status = Proto.Enum.PlayerDiggingStatus.FinishedDigging;
			await Agent.Send(playerDigging);

			OnComplete(this);
		}

		public void OnBlockChanged(Agent sender, Int3 position, World world)
		{
			// TODO проверять заслоняет ли блок
			if (position != _blockPosition) return;

			swingHandTokenSource.Cancel();
			sender.UnsubscribeOnBlockChanged(this);
		}

		public async void SwingHand(Agent agent, CancellationToken jobCancellationToken, CancellationToken swingCancellationToken)
		{
			var playerDigging = new AnimationPacket()
			{
				Hand = Proto.Enum.HandType.Main
			};

			while (!jobCancellationToken.IsCancellationRequested && !swingCancellationToken.IsCancellationRequested)
			{
				await agent.Send(playerDigging);
				await Task.Delay(_swingDelay);
			}
			OnComplete(this);
		}
	}
}
