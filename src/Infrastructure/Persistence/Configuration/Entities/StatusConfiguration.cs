using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Numployable.Domain;

namespace Numployable.Persistence.Configuration.Entities;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasKey(e => e.Id).HasName("Status_PRIMARY");
        builder.HasIndex(e => e.Description).IsUnique();

        builder.HasData(
            new Status { Id = 1, Description = "Active" },
            new Status { Id = 2, Description = "Expired" },
            new Status { Id = 3, Description = "Closed" }
        );
    }
}