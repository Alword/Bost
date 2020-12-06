using Bost.Deductions.Model;
using System;
using System.Net;

namespace Bost.Deductions
{
	public class SemanticFile
	{
		public static readonly string Path = "https://drive.google.com/u/0/uc?id=1dZbzbNHOM5lDBf0AvkC83qm8fp8C8_jq&export=download";
		public string XmlString { get; private set; }
		public SemanticFile()
		{
			var xml = new WebClient();
			XmlString = xml.DownloadString(Path);
		}
		public Graph<object> BuildGraph()
		{
			return new Graph<object>(XmlString);
		}
	}
}
