namespace Numployable.Persistence;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Numployable.Application.Persistence.Contracts;
using Repositories;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NumployableDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("NumployableDatabase")));

        services.AddScoped<ICommuteRepository, CommuteRepository>();
        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        services.AddScoped<INextActionRepository, NextActionRepository>();
        services.AddScoped<INextActionTypeRepository, NextActionTypeRepository>();
        services.AddScoped<IProcessStatusRepository, ProcessStatusRepository>();
        services.AddScoped<IRoleTypeRepository, RoleTypeRepository>();
        services.AddScoped<ISourceRepository, SourceRepository>();
        services.AddScoped<IStatusRepository, StatusRepository>();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}