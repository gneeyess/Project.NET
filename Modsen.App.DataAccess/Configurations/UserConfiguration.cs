using Dal.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Modsen.App.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder) 
    {
        builder.HasKey(user => user.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(15);
        builder.Property(user => user.LastName).IsRequired().HasMaxLength(15);
    }
}