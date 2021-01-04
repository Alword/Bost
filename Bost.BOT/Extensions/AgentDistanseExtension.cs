using Bost.Agent.Extentions;
using Bost.Agent.Model;
using Bost.Proto.Mapping.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Agent.Extensions
{
	public static class AgentDistanseExtension
	{
		/// <summary>
		/// Returns all blocks in the volume from a to b
		/// </summary>
		/// <param name="a">start position</param>
		/// <param name="b">end position</param>
		/// <returns></returns>
		public static (BlockState block, Int3 position)[] GetBlocks(this IAgent agent, Int3 a, Int3 b)
		{
			var world = agent.World;

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
		public static int DistanceTo(this IAgent agent, Int3 position)
		{
			Int3 location = (Int3)agent.Position;
			return location.Distance(position);
		}
	}
}
