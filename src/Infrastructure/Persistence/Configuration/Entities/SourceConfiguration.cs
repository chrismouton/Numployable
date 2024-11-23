using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Numployable.Domain;

namespace Numployable.Persistence.Configuration.Entities;

public class SourceConfiguration : IEntityTypeConfiguration<Source>
{
    public void Configure(EntityTypeBuilder<Source> builder)
    {
        builder.HasKey(e => e.Id).HasName("Source_PRIMARY");
        builder.HasIndex(e => e.Description).IsUnique();

        builder.HasData(
            new Source { Id = 1, Description = "Job board" },
            new Source { Id = 2, Description = "Networking" },
            new Source { Id = 3, Description = "Recruiter contact" },
            new Source { Id = 4, Description = "Recruiting site" }
        );
    }
}
