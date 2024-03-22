using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Book.API;

public static class ServiceCollectionExtension
{
    public static IHostApplicationBuilder AddCustomDbContext(this IHostApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services
            .AddDbContext<BookContext>(options =>
            {
                options.UseSqlServer(
                    configuration["ConnectionStrings:SqlServer"],
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            });

        return builder;
    }

    public static IHostApplicationBuilder AddSwagger(this IHostApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new() { Title = "Book API", Version = "v1" });
            opt.TagActionsBy(d =>
            {
                return [d.ActionDescriptor.DisplayName!];
            });
        });

        return builder;
    }

    public static WebApplication UseSwaggerApi(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
