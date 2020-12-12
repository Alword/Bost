using Bost.Deductions.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bost.Deductions.Model
{
	public class ShapeNetwork
	{
		public static readonly List<Shape> Shapes;
		static ShapeNetwork()
		{
			Shapes = new List<Shape>
			{
				new Arrow(),
				new Ellipse(),
				new Cube(),
				new Rectangle(),
			};
		}
		public List<Arrow> Arrows { get; set; }
		public List<Rectangle> Rectangles { get; set; }
		public List<Cube> Cubes { get; set; }
		public List<Ellipse> Ellipses { get; set; }
		public Dictionary<string, Shape> Nodes { get; set; }
		public ShapeNetwork(string xmlstring)
		{
			Arrows = new List<Arrow>();
			Nodes = new Dictionary<string, Shape>();
			Cubes = new List<Cube>();
			Ellipses = new List<Ellipse>();
			Rectangles = new List<Rectangle>();

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xmlstring);

			if (doc.DocumentElement == null) return;

			XmlNodeList? shapes = doc.DocumentElement.SelectNodes("/mxGraphModel/root/mxCell");
			if (shapes == null) return;

			foreach (XmlNode shapeNode in shapes)
			{
				if (shapeNode.Attributes == null) continue;
				var shape = SwitchShape(shapeNode);
				var addShape = SwitchShapeBehavior(shape);
				addShape();
			}

			foreach (var arrow in Arrows)
			{
				if (Nodes.ContainsKey(arrow.Source) && Nodes.ContainsKey(arrow.Target))
				{
					var sourse = Nodes[arrow.Source];
					var target = Nodes[arrow.Target];
					sourse.Outgoing.Add(target);
					target.Incoming.Add(sourse);
				}
			}
			Arrows.Clear();
		}

		public Action SwitchShapeBehavior(Shape? shape) => shape switch
		{
			Arrow s => () => AddArrow(s),
			Ellipse s => () => AddEllipse(s),
			Cube s => () => AddCube(s),
			Rectangle s => () => AddRectangle(s),
			_ => () => { }
		};

		public void AddArrow(Arrow arrow) { Arrows.Add(arrow); }
		public void AddEllipse(Ellipse ellipse) { Ellipses.Add(ellipse); AddShape(ellipse); }
		public void AddCube(Cube ellipse) { Cubes.Add(ellipse); AddShape(ellipse); }
		public void AddRectangle(Rectangle ellipse) { Rectangles.Add(ellipse); AddShape(ellipse); }

		public void AddShape(Shape shape)
		{
			if (shape.Id == string.Empty) return;
			Nodes.Add(shape.Id, shape);
		}

		public static Shape? SwitchShape(XmlNode shapeNode)
		{
			foreach (var shape in Shapes)
			{
				var currentShape = shape.VlidateShape(shapeNode);
				if (currentShape != null)
				{
					return currentShape;
				}
			}
			return null;
		}
	}
}
