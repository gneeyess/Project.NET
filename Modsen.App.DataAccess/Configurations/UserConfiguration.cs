using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modsen.App.Core.Models;

namespace Modsen.App.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Id).IsUnique();
            builder.Property(user => user.FirstName).IsRequired().HasMaxLength(15);
            builder.Property(user => user.LastName).IsRequired().HasMaxLength(15);
            builder.Property(user => user.Email).HasMaxLength(50);
            builder.Property(user => user.Phone).IsRequired().HasMaxLength(9); // +375 (xx) xxx-xx-xx
            builder.Property(user => user.PasswordHash).IsRequired().HasMaxLength(250);
        }
    }
}
