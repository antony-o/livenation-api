namespace LiveNation.Api;

using Hellang.Middleware.ProblemDetails;
using LiveNation.Api.RulesEngine;
using LiveNation.Api.Services;

public static class Startup
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddProblemDetails(ConfigureProblemDetails);
        services.AddControllers();

        // Add Swagger/OpenAPI
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // Add memoryCache
        services.AddMemoryCache();

        //App Registrations
        services.AddTransient<INumberService, NumberService>();
        services.AddTransient<IRulesEngine, RulesEngine.RulesEngine>();
        services.AddSingleton<ICacheService, CacheService>();
    }

    public static void ConfigurePipeline(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseProblemDetails();  //Consistent api error formatting using problemdetails

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }

    private static void ConfigureProblemDetails(ProblemDetailsOptions options)
    {
        options.MapToStatusCode<ArgumentOutOfRangeException>(StatusCodes.Status400BadRequest);
        options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
    }
}
