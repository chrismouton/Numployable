namespace Numployable.Persistence.Configuration.Entities;

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class JobApplicationConfiguration : IEntityTypeConfiguration<Domain.JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.HasKey(e => e.Id).HasName("JobApplication_PRIMARY");

        builder
            .HasOne(d => d.Commute)
            .WithMany(p => p.JobApplication)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("JobApplication_Commute_FK");

        builder
            .HasOne(d => d.ProcessStatus)
            .WithMany(p => p.JobApplication)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("JobApplication_ProcessStatus_FK");

        builder
            .HasOne(d => d.RoleType)
            .WithMany(p => p.JobApplication)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("JobApplication_RoleType_FK");

        builder
            .HasOne(d => d.Source)
            .WithMany(p => p.JobApplication)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("JobApplication_Source_FK");

        builder
            .HasOne(d => d.Status)
            .WithMany(p => p.JobApplication)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("JobApplication_Status_FK");
    }
}
