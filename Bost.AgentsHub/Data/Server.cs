using System.ComponentModel.DataAnnotations;

namespace Bost.AgentsHub.Data
{
	public class Server
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string IpPort { get; set; }
	}
}
