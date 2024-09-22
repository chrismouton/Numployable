namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Numployable.Persistence.Model;

public class JobApplicationConfiguration : IEntityTypeConfiguration<Domain.JobApplication>
{
    public void Configure(EntityTypeBuilder<Domain.JobApplication> builder)
    {
        builder.HasKey(e => e.Id).HasName("JobApplication_PRIMARY");
    }
}