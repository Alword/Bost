using System;
using Xunit;

namespace Bost.Deductions.Tests
{
	public class DigramDownload
	{
		[Fact]
		public void DigramDownload_ShouldBeFine()
		{
			SemanticFile semantic = new();
			var graph = semantic.BuildGraph();
		}
	}
}
