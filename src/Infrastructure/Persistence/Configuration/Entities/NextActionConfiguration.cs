namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Model;

public class NextActionConfiguration : IEntityTypeConfiguration<Domain.NextAction>
{
    public void Configure(EntityTypeBuilder<Domain.NextAction> builder)
    {
        builder.HasKey(e => e.Id).HasName("NextAction_PRIMARY");
    }
}