using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.API.Abstractions;
using RepositoryDesignPattern.API.Concretes;
using RepositoryDesignPattern.API.Context;

namespace RepositoryDesignPattern.API;

public static class ServiceExtension
{
    private static readonly string _connectionStr = @"Server=localhost;Database=RepositoryDesignPatternDB;Trusted_Connection=True;";
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddDbContext<RepositoryDesignPatternDbContext>(opt =>
        {
            opt.UseSqlServer(_connectionStr);
        });

        services.AddScoped<RepositoryDesignPatternDbContextInitializer>();

        services.AddScoped<IMyEntityReadRepository, MyEntityReadRepository>();
        services.AddScoped<IMyEntityWriteRepository, MyEntityWriteRepository>();
    }
}
