using Bost.Agent.Events;
using Bost.Agent.Model;
using System.Collections.Generic;
using System.Linq;

namespace Bost.Agent
{
	public partial class Agent
	{
		private readonly List<IBlockChangedEventHandler> _blockChangedEventHandlers = new List<IBlockChangedEventHandler>();
		public void OnOnBlockChanged(Int3 position, World world)
		{
			if (!_blockChangedEventHandlers.Any()) return;
			foreach (var handler in _blockChangedEventHandlers.ToArray())
			{
				handler.OnBlockChanged(this, position, world);
			}
		}
		public void SubscribeOnBlockChanged(IBlockChangedEventHandler blockChangedEventHandler)
		{
			lock (_blockChangedEventHandlers)
			{
				_blockChangedEventHandlers.Add(blockChangedEventHandler);
			}
		}
		public void UnsubscribeOnBlockChanged(IBlockChangedEventHandler blockChangedEventHandler)
		{
			lock (_blockChangedEventHandlers)
			{
				_ = _blockChangedEventHandlers.Remove(blockChangedEventHandler);
			}
		}
	}
}
