namespace Numployable.Persistence.Configuration.Entities;

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProcessStatusConfiguration : IEntityTypeConfiguration<ProcessStatus>
{
    public void Configure(EntityTypeBuilder<ProcessStatus> builder)
    {
        builder.HasKey(e => e.Id).HasName("ProcessStatus_PRIMARY");
        builder.HasIndex(e => e.Description).IsUnique();

        builder.HasData(
            new ProcessStatus { Id = 1, Description = "Applied" },
            new ProcessStatus { Id = 2, Description = "Interviewing" },
            new ProcessStatus { Id = 3, Description = "Waiting response" },
            new ProcessStatus { Id = 4, Description = "Offer received" },
            new ProcessStatus { Id = 5, Description = "Hired" },
            new ProcessStatus { Id = 6, Description = "Rejected" },
            new ProcessStatus { Id = 7, Description = "Retracted" }
        );
    }
}
