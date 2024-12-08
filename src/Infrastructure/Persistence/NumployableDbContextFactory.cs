using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Numployable.Persistence;

public class NumployableDbContextFactory : IDesignTimeDbContextFactory<NumployableDbContext>
{
    public NumployableDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<NumployableDbContext>? optionsBuilder = new();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Numployable;Username=postgres;PWD=password1!");

        return new NumployableDbContext(optionsBuilder.Options);
    }
}