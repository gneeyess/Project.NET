using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modsen.App.Core.Models;

namespace Modsen.App.DataAccess.Configurations
{
    public class TransportConfiguration : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.HasKey(transport => transport.Id);
            builder.HasIndex(transport => transport.Id).IsUnique();
            builder.Property(transport => transport.Name).IsRequired().HasMaxLength(15);
        }
    }
}
