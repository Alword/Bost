using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bost.Deductions.Model.Shapes
{
	public class Arrow : Shape
	{
		public string Source { get; set; }
		public string Target { get; set; }
		public Arrow()
		{
			Source = string.Empty;
			Target = string.Empty;
		}

		public override Shape? VlidateShape(XmlNode xmlNode)
		{
			if (xmlNode.Attributes == null) return null;

			var source = xmlNode.Attributes["source"]?.Value;
			var target = xmlNode.Attributes["target"]?.Value;

			if (source == null && target == null) return null;

			return new Arrow()
			{
				Source = source ?? string.Empty,
				Target = target ?? string.Empty
			};
		}
	}
}
