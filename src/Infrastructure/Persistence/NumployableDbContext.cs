namespace Numployable.Persistence;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Numployable.Domain;

public class NumployableDbContext : DbContext
{
    public NumployableDbContext(DbContextOptions<NumployableDbContext> options)
        : base(options)
    {        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NumployableDbContext).Assembly);
    }

    public DbSet<JobApplication> JobApplications {get; set;}

    public DbSet<NextAction> NextActions { get; set; }
}