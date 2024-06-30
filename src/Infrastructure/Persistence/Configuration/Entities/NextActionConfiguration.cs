namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Numployable.Persistence.Model;

public class NextActionConfiguration : IEntityTypeConfiguration<NextAction>
{
    public void Configure(EntityTypeBuilder<NextAction> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.HasOne(d => d.JobApplication).WithMany(p => p.NextAction)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("NextAction_JobApplication_FK");

        builder.HasOne(d => d.NextActionType).WithMany(p => p.NextAction)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("NextAction_NextActionType_FK");

        builder.Property(e => e.NextActionTypeId).HasConversion<int>();
    }
}