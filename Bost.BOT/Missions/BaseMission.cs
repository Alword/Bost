namespace Bost.Agent.Missions
{
	public abstract class BaseMission
	{
		public BaseMission()
		{
		}

		public abstract void SendJob(IAgent agent);
	}
}
