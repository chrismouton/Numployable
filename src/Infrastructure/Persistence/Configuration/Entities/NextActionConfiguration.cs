namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class NextActionConfiguration : IEntityTypeConfiguration<Domain.NextAction>
{
    public void Configure(EntityTypeBuilder<Domain.NextAction> builder)
    {
        builder.HasKey(e => e.Id).HasName("NextAction_PRIMARY");

        builder
            .HasOne(d => d.JobApplication)
            .WithMany(p => p.NextAction)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("NextAction_JobApplication_FK");

        builder
            .HasOne(d => d.NextActionType)
            .WithMany(p => p.NextAction)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("NextAction_NextActionType_FK");
    }
}
