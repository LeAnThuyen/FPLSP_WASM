using ApiUser.Datasbase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace ApiUser.Factories
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .AddUserSecrets(Assembly.GetAssembly(typeof(Startup)))
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            optionsBuilder.UseSqlServer(config.GetConnectionString("Conn"), sqlServerOptionsAction: o => o.MigrationsAssembly(typeof(Startup).Assembly.FullName));

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
