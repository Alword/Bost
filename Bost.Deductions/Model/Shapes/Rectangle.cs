using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bost.Deductions.Model.Shapes
{
	public class Rectangle : Shape
	{
		public Rectangle() { }
		public Rectangle(XmlNode? node) : base(node) { }
		public override Shape? VlidateShape(XmlNode xmlNode)
		{
			return new Rectangle(xmlNode);
		}
	}
}
