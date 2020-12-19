using System;

namespace Bost.Proto.Mapping.Generator
{
	public class BlockState
	{
		public uint Id { get; set; }
		public string Name { get; set; }

		public override bool Equals(object obj)
		{
			return obj is BlockState state &&
				   Id == state.Id &&
				   Name == state.Name;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Name);
		}
	}
}