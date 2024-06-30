namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Numployable.Helpers;
using Numployable.Persistence.Model;

public class SourceConfiguration : IEntityTypeConfiguration<Source>
{
    public void Configure(EntityTypeBuilder<Source> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");
        builder.Property(e => e.Id).HasConversion<int>();
        builder.HasData(
                Enum.GetValues(typeof(Numployable.Source))
                    .Cast<Numployable.Source>()
                    .Select(e => new Source()
                    {
                        Id = e,
                        Description = Helpers.GetDescription(e)
                    })
            );

    }
}