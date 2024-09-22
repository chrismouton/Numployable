namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;

public class NextActionTypeConfiguration : IEntityTypeConfiguration<NextActionType>
{
    public void Configure(EntityTypeBuilder<NextActionType> builder)
    {
        builder.HasKey(e => e.Id).HasName("NextActionType_PRIMARY");
        builder.HasIndex(e => e.Description).IsUnique();

        builder.HasData(
            new NextActionType
            {
                Id = 1,
                Description = "Suggest time slots"
            },
            new NextActionType
            {
                Id = 2,
                Description = "Initial call"
            },
            new NextActionType
            {
                Id = 3,
                Description = "Interview"
            }
        );
    }
}