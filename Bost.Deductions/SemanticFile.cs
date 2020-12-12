using Bost.Deductions.Model;
using System;
using System.Net;

namespace Bost.Deductions
{
	public class SemanticFile
	{
		private static readonly string _path = "https://drive.google.com/u/0/uc?id=1dZbzbNHOM5lDBf0AvkC83qm8fp8C8_jq&export=download";
		private string _xmlString;
		public SemanticFile()
		{
			var xml = new WebClient();
			_xmlString = xml.DownloadString(_path);
		}
		public ShapeNetwork BuildGraph()
		{
			var xml = DiagramsDecompressor.Decompress(ref _xmlString);
			return new ShapeNetwork(xml);
		}
	}
}
