namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Helpers;
using Model;

public class NextActionTypeConfiguration : IEntityTypeConfiguration<NextActionType>
{
    public void Configure(EntityTypeBuilder<NextActionType> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");
        builder.Property(e => e.Id).HasConversion<int>();
        builder.HasData(Enum.GetValues(typeof(Numployable.NextActionType))
            .Cast<Numployable.NextActionType>()
            .Select(e => new NextActionType()
            {
                Id = e,
                Description = Helpers.GetDescription(e)
            })
        );
    }
}