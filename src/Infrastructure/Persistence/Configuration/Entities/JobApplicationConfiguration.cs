namespace Numployable.Persistence.Configuration.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Model;

public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.AdvertisedSalary).HasDefaultValueSql("'NULL'");
        builder.Property(e => e.CommuteId).HasDefaultValueSql("'NULL'");
        builder.Property(e => e.Location).HasDefaultValueSql("'NULL'");
        builder.Property(e => e.Note).HasDefaultValueSql("'NULL'");
        builder.Property(e => e.Url).HasDefaultValueSql("'NULL'");

        builder.HasOne(d => d.Commute).WithMany(p => p.JobApplication)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("JobApplication_Commute_FK");

        builder.HasOne(d => d.ProcessStatus).WithMany(p => p.JobApplication)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("JobApplication_ProcessStatus_FK");

        builder.HasOne(d => d.RoleType).WithMany(p => p.JobApplication)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("JobApplication_RoleType_FK");

        builder.HasOne(d => d.Source).WithMany(p => p.JobApplication)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("JobApplication_Source_FK");

        builder.HasOne(d => d.Status).WithMany(p => p.JobApplication)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("JobApplication_Status_FK");


        builder.Property(e => e.CommuteId).HasConversion<int>();
        builder.Property(e => e.ProcessStatusId).HasConversion<int>();
        builder.Property(e => e.RoleTypeId).HasConversion<int>();
        builder.Property(e => e.SourceId).HasConversion<int>();
        builder.Property(e => e.StatusId).HasConversion<int>();
        
    }
}