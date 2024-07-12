namespace Numployable.UI.Web;

using System.Reflection;

using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Services;
using Numployable.UI.Web.Services.Base;

public class StartUp (IConfiguration configuration)
{
    public IConfiguration Configuration { get; private set; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("http://localhost:5093"));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<INextActionService, NextActionService>();

        services.AddSingleton<ILocalStorageService, LocalStorageService>();

        services.AddControllersWithViews();
    }
}