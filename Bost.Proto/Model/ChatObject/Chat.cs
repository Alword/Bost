using System.Collections.Generic;
using System.Linq;

namespace Bost.Proto.Model.ChatObject
{
	public class Chat
	{
		public List<Extra> extra { get; set; }
		public string text { get; set; }
		public Chat()
		{
			extra = new List<Extra>();
		}

		public string GetText() => string.Join("", extra.Select(e => e.text));

		public override string ToString()
		{
			return $"{text} {GetText()}";
		}
	}
}
