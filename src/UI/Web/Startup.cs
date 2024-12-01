using System.Reflection;

using Microsoft.AspNetCore.Authentication.Cookies;

using Numployable.APIClient.Client;
using Numployable.APIClient.Contracts;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Services;

namespace Numployable.UI.Web;

public class Startup(IConfiguration configuration)
{
  // This method gets called by the runtime. Use this method to add services to the container.
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddHttpContextAccessor();

    services.Configure<CookiePolicyOptions>(options =>
    {
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
        {
          options.LoginPath = new PathString("/users/login");
        });

    //services.AddTransient<IAuthenticationService, AuthenticationService>();

    services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("http://localhost:5093"));
    services.AddAutoMapper(Assembly.GetExecutingAssembly());

    services.AddScoped<IApplicationProcessStatusService, ApplicationProcessStatusService>();
    services.AddScoped<IApplicationStatusService, ApplicationStatusService>();
    services.AddScoped<ICommuteService, CommuteService>();
    services.AddScoped<IJobApplicationService, JobApplicationService>();
    services.AddScoped<INextActionService, NextActionService>();
    services.AddScoped<IDashboardService, DashboardService>();
    services.AddScoped<IRoleTypeService, RoleTypeService>();

    services.AddSingleton<ILocalStorageService, LocalStorageService>();
    services.AddControllersWithViews();
  }

  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
    }
    else
    {
      app.UseExceptionHandler("/Home/Error");
      // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
      app.UseHsts();
    }


    app.UseCookiePolicy();
    app.UseAuthentication();

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    //app.UseMiddleware<RequestMiddleware>();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
    });
  }
}
