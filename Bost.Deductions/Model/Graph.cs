using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bost.Deductions.Model
{
	public class Graph<T>
	{
		public Dictionary<string, Node<T>> Nodes { get; set; }
		public Graph(string xmlstring)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xmlstring);

			XmlNodeList errorNodes = doc.DocumentElement.SelectNodes("/mxfile/diagram/mxGraphModel/root");

			foreach (XmlNode errorNode in errorNodes)
			{
				string id = errorNode.Attributes["id"].Value;
				string value = errorNode.Attributes["value"].Value;
				string style = errorNode.Attributes["style"].Value;
			}
		}
	}
}
