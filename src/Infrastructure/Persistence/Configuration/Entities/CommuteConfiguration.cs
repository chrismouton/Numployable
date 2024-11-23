using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Numployable.Domain;

namespace Numployable.Persistence.Configuration.Entities;

public class CommuteConfiguration : IEntityTypeConfiguration<Commute>
{
    public void Configure(EntityTypeBuilder<Commute> builder)
    {
        builder.HasKey(e => e.Id).HasName("Commute_PRIMARY");
        builder.HasIndex(e => e.Description).IsUnique();

        builder.HasData(
            new Commute { Id = 1, Description = "On-site" },
            new Commute { Id = 2, Description = "Remote" },
            new Commute { Id = 3, Description = "Hybrid" }
        );
    }
}
