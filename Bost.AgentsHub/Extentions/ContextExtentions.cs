using Bost.AgentsHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bost.AgentsHub.Extentions
{
    public static class ContextExtentions
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
            path = Path.Combine(path, "Bost", "agents.db");

            Directory.CreateDirectory(Path.GetDirectoryName(path));

            var options = new DbContextOptionsBuilder<AgentsContext>()
                .UseSqlite($"Data Source={path};");

            using (var context = new AgentsContext(options.Options))
            {
                context.Database.Migrate();
            }

            services.AddDbContext<AgentsContext>(e => e.UseSqlite($"Data Source={path};"));
            return services;
        }
    }
}
