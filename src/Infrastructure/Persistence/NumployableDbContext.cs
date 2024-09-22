namespace Numployable.Persistence;

using System.Reflection;
using Microsoft.EntityFrameworkCore;

using Domain;

public partial class NumployableDbContext : DbContext
{
    public NumployableDbContext()
    {
    }

    public NumployableDbContext(DbContextOptions<NumployableDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Commute> Commute { get; set; }

    public virtual DbSet<JobApplication> JobApplication { get; set; }

    public virtual DbSet<NextAction> NextAction { get; set; }

    public virtual DbSet<NextActionType> NextActionType { get; set; }

    public virtual DbSet<ProcessStatus> ProcessStatus { get; set; }

    public virtual DbSet<RoleType> RoleType { get; set; }

    public virtual DbSet<Source> Source { get; set; }

    public virtual DbSet<Status> Status { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}