using ApiUser.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiUser.Datasbase.Configuration
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(c => c.FistName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
        }
    }
}
