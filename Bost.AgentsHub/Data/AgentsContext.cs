using Microsoft.EntityFrameworkCore;

namespace Bost.AgentsHub.Data
{
	public class AgentsContext : DbContext
	{
		public DbSet<Server> Servers { get; set; }

		public AgentsContext(DbContextOptions options) : base(options)
		{

		}
	}
}
