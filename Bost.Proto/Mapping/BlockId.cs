﻿using Bost.Proto.Mapping.Generator;

namespace Bost.Proto.Mapping
{
	public struct BlockId
	{
		public uint StateId { get; set; }

		public BlockId(uint id)
		{
			StateId = id;
		}

		public override string ToString()
		{
			return $"{StateId} {GlobalPalette.GetState(StateId).Name}";
		}
	}
}
