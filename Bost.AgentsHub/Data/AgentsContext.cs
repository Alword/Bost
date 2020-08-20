using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bost.AgentsHub.Data
{
    public class AgentsContext : DbContext
    {
        public DbSet<Server> Servers { get; set; }

        public AgentsContext(DbContextOptions<AgentsContext> options) : base(options)
        {

        }
    }
}
