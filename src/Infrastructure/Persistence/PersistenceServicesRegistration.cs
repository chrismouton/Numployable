namespace Numployable.Persistence;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Numployable.Application.Persistence.Contracts;
using Profiles;
using Repositories;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NumployableDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("NumployableDatabase")));

        services.AddScoped<IDashboardRepository, DashboardRepository>();
        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        services.AddScoped<INextActionRepository, NextActionRepository>();

        services.AddAutoMapper(typeof(MappingProfile));
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}