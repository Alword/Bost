using Bost.AgentsHub.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Bost.AgentsHub.Extentions
{
    public static class ContextExtentions
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
            path = Path.Combine(path, "Bost", "agents.db");

            Directory.CreateDirectory(Path.GetDirectoryName(path));

            services.AddDbContext<AgentsContext>(e => e.UseSqlite($"Data Source={path};"));

            return services;
        }

        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
            {
                using var context = serviceScope.ServiceProvider.GetService<AgentsContext>();
                context.Database.Migrate();
            }

            return app;
        }
    }
}
