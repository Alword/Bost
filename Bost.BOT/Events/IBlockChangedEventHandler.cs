using Bost.Agent.Model;

namespace Bost.Agent.Events
{
	public interface IBlockChangedEventHandler
	{
		void OnBlockChanged(Agent sender, Int3 position, World world);
	}
}
