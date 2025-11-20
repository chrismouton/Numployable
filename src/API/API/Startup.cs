using Numployable.API.Middleware;
using Numployable.Application;
using Numployable.Persistence;

namespace Numployable.API;

public class Startup(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddOpenApi(options =>
        {
            // Specify the OpenAPI version to use
            options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;
        });

        services.ConfigureApplicationServices();
        //services.ConfigureInfrastructureServices(_configuration); - No infrastrucutre yet
        services.ConfigurePersistenceServices(_configuration);
        //services.ConfigureIdentityServices(_configuration); - Coming later

        services.AddControllers();

        services.AddCors(o =>
        {
            o.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseAuthentication();

        //app.UseSwagger();
        //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Numployable.Api v1"));

        //app.UseHttpsRedirection(); - Currently broken

        app.UseRouting();

        //app.UseAuthorization();

        app.UseCors("CorsPolicy");

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}