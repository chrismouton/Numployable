namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Model;

public class CommuteConfiguration : IEntityTypeConfiguration<Commute>
{
    public void Configure(EntityTypeBuilder<Commute> builder)
    {
        builder.HasKey(e => e.Id).HasName("Commute_PRIMARY");

        builder.HasData(
            new Commute
            {
                Id = 1,
                Description = "On-site"
            },
            new Commute
            {
                Id = 2,
                Description = "Remote"
            },
            new Commute
            {
                Id = 3,
                Description = "Hybrid"
            }
        );
    }
}