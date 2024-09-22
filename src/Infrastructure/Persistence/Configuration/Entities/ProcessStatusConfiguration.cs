namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Model;

public class ProcessStatusConfiguration : IEntityTypeConfiguration<ProcessStatus>
{
    public void Configure(EntityTypeBuilder<ProcessStatus> builder)
    {
        builder.HasKey(e => e.Id).HasName("ProcessStatus_PRIMARY");
    }
}