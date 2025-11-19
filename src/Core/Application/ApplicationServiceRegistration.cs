using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Numployable.Application.Profiles;

namespace Numployable.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { }, typeof(MappingProfile));
        services.AddMediatR(config => { config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });

        return services;
    }
}