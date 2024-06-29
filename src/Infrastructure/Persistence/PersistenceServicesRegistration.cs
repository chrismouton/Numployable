namespace Numployable.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Numployable.Application.Persistence.Contracts;
using Numployable.Persistence.Repositories;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NumployableDbContext>(options => options.UseMySQL(configuration.GetConnectionString("NumployableConnectionString")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        services.AddScoped<INextActionRepository, NextActionRepository>();

        return services;
    }
}