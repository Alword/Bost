namespace Bost.Shared
{
	public class ServerStatusData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string CoreName { get; set; }
		public string IpPort { get; set; }
		public int Proto { get; set; }
		public int Online { get; set; }
		public int Max { get; set; }
		public string OnlineMax { get => $"{Online}/{Max}"; }
	}
}
