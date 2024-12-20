using Microsoft.OpenApi.Models;
using Numployable.API.Middleware;
using Numployable.Application;
using Numployable.Persistence;

namespace Numployable.API;

public class Startup(IConfiguration configuration)
{
    public readonly IConfiguration _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        AddSwaggerDoc(services);

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
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseAuthentication();

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Numployable.Api v1"));

        //app.UseHttpsRedirection(); - Currently broken

        app.UseRouting();

        //app.UseAuthorization();

        app.UseCors("CorsPolicy");

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

    private static void AddSwaggerDoc(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Numployable Api"
            });
        });
    }
}