using Bost.Agent.Extentions;
using Bost.Agent.Model;
using Bost.Agent.State;
using Bost.Proto.Mapping.Generator;
using System.Collections.Generic;

namespace Bost.Agent
{
	public partial class Agent
	{
		public World World => GameState.World;
		/// <summary>
		/// Returns all blocks in the volume from a to b
		/// </summary>
		/// <param name="a">start position</param>
		/// <param name="b">end position</param>
		/// <returns></returns>
		public (BlockState block, Int3 position)[] GetBlocks(Int3 a, Int3 b)
		{
			var world = World;

			(var min, var max) = Сompare.MinMax(a, b);

			List<(BlockState, Int3)> blockStates = new List<(BlockState, Int3)>(Int3.Volume(min, max));

			for (int x = min.X; x <= max.X; x++)
			{
				for (int y = min.Y; y <= max.Y; y++)
				{
					for (int z = min.Z; z <= max.Z; z++)
					{
						var pos = new Int3(x, y, z);
						blockStates.Add((world[pos], pos));
					}
				}
			}
			return blockStates.ToArray();

		}
		public int DistanceTo(Int3 position)
		{
			var currentPosition = GameState.Bot.Position;
			Int3 location = new((int)currentPosition.X, (int)currentPosition.Y, (int)currentPosition.Z);
			return location.Distance(position);
		}
	}
}
