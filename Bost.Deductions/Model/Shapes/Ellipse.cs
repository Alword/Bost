using Bost.Deductions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bost.Deductions.Model.Shapes
{
	public class Ellipse : Shape
	{
		public Colors Color { get; set; }
		public Ellipse() { }
		public Ellipse(Colors color, string id, string? value) : base(id, value)
		{
			Color = color;
		}

		public Ellipse(Colors color, XmlNode? value) : base(value)
		{
			Color = color;
		}

		public override Shape? VlidateShape(XmlNode xmlNode)
		{
			if (xmlNode.Attributes == null) return null;

			var style = xmlNode.Attributes["style"]?.Value;

			if (style == null || !style.StartsWith("ellipse")) return null;

			var colorString = string.Empty;
			var colorStringIndex = style.IndexOf("fillColor=");

			if (colorStringIndex > -1)
			{
				colorString = style[colorStringIndex..(colorStringIndex + 7)];
			}

			return new Ellipse(ColorsSwitch.FromRgb(colorString), xmlNode);
		}
	}
}
