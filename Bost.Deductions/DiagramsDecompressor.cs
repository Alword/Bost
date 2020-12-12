using Bost.Deductions.Model;
using Shuttle.Core.Compression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bost.Deductions
{
	public static class DiagramsDecompressor
	{
		/// <summary>
		/// Decompress .drawio file
		/// </summary>
		/// <param name="drawio"></param>
		/// <returns></returns>
		public static string Decompress(ref string drawio)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(drawio);
			var encoded = xmlDocument.InnerText;

			var base64String = Convert.FromBase64String(encoded);
			var algorithm = new DeflateCompressionAlgorithm();
			var deflated = algorithm.Decompress(base64String);
			var endodedUri = Encoding.UTF8.GetString(deflated);
			var xml = Uri.UnescapeDataString(endodedUri);
			return xml;
		}
	}
}
