namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Numployable.Helpers;
using Numployable.Persistence.Model;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");
        builder.Property(e => e.Id).HasConversion<int>();
        builder.HasData(
                Enum.GetValues(typeof(Numployable.Status))
                    .Cast<Numployable.Status>()
                    .Select(e => new Status()
                    {
                        Id = e,
                        Description = Helpers.GetDescription(e)
                    })
            );
    }
}