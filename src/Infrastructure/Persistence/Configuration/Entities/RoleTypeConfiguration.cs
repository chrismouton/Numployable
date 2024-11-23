using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Numployable.Domain;

namespace Numployable.Persistence.Configuration.Entities;

public class RoleTypeConfiguration : IEntityTypeConfiguration<RoleType>
{
    public void Configure(EntityTypeBuilder<RoleType> builder)
    {
        builder.HasKey(e => e.Id).HasName("RoleType_PRIMARY");
        builder.HasIndex(e => e.Description).IsUnique();

        builder.HasData(
            new RoleType { Id = 1, Description = "Permanent" },
            new RoleType { Id = 2, Description = "Contract" },
            new RoleType { Id = 3, Description = "Part time" },
            new RoleType { Id = 4, Description = "Fixed-term contract" },
            new RoleType { Id = 5, Description = "Volunteering" },
            new RoleType { Id = 6, Description = "Temporary full-time" }
        );
    }
}
