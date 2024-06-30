namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Numployable.Helpers;
using Numployable.Persistence.Model;

public class CommuteConfiguration : IEntityTypeConfiguration<Commute>
{
    public void Configure(EntityTypeBuilder<Commute> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");
        builder.Property(e => e.Id).HasConversion<int>();
        builder.HasData(
                Enum.GetValues(typeof(Numployable.Commute))
                    .Cast<Numployable.Commute>()
                    .Select(e => new Commute()
                    {
                        Id = e,
                        Description = Helpers.GetDescription(e)
                    })
            );

    }
}