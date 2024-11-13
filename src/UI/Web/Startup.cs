namespace Numployable.UI.Web;

using System.Reflection;

using APIClient.Client;
using APIClient.Contracts;
using Contracts;
using Services;

public class StartUp (IConfiguration configuration)
{
    public IConfiguration Configuration { get; private set; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("http://localhost:5055"));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<INextActionService, NextActionService>();

        services.AddSingleton<ILocalStorageService, LocalStorageService>();

        services.AddControllersWithViews();
    }
}
