namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Model;

public class RoleTypeConfiguration : IEntityTypeConfiguration<RoleType>
{
    public void Configure(EntityTypeBuilder<RoleType> builder)
    {
        builder.HasKey(e => e.Id).HasName("RoleType_PRIMARY");
    }
}