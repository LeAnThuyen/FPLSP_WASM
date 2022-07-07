using ApiUser.Datasbase.Configuration;
using ApiUser.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiUser.Datasbase
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserConfig());
        }

    }
}
