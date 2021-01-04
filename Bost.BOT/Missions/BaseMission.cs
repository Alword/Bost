namespace Bost.Agent.Missions
{
	public abstract class BaseMission
	{
		public BaseMission()
		{
		}

		public abstract bool SendJob(IAgent agent);
	}
}
