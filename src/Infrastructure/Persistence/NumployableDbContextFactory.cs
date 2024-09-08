namespace Numployable.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class NumployableDbContextFactory : IDesignTimeDbContextFactory<NumployableDbContext>
{
    public NumployableDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<NumployableDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Numployable;Username=postgres;PWD=password1!");

        return new NumployableDbContext(optionsBuilder.Options);
    }
}