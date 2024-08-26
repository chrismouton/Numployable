namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Helpers;
using Model;

public class ProcessStatusConfiguration : IEntityTypeConfiguration<ProcessStatus>
{
    public void Configure(EntityTypeBuilder<ProcessStatus> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");
        builder.Property(e => e.Id).HasConversion<int>();
        builder.HasData(
                Enum.GetValues(typeof(Numployable.ProcessStatus))
                    .Cast<Numployable.ProcessStatus>()
                    .Select(e => new ProcessStatus()
                    {
                        Id = e,
                        Description = Helpers.GetDescription(e)
                    })
            );


    }
}