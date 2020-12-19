using System.Collections.Generic;

namespace Bost.Proto.Mapping.Generator
{
	public class GeneratedBlock
	{
		public List<GeneratedState> States { get; set; }
		public class GeneratedState
		{
			public uint Id { get; set; }
			public bool Default { get; set; }
		}
	}
}
