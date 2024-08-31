using RepositoryDesignPattern.API.Abstractions;
using RepositoryDesignPattern.API.Concretes;
using RepositoryDesignPattern.API.Context;
using RepositoryDesignPattern.API.Entities;

namespace RepositoryDesignPattern.API;

public static class ServiceExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        
        services.AddScoped<RepositoryDesignPatternDbContextInitializer>();

        //Generic Repository Scopes
        services.AddScoped<IReadRepository<MyEntity>, ReadRepository<MyEntity>>();
        services.AddScoped<IWriteRepository<MyEntity>, WriteRepository<MyEntity>>();

        //Custom Repository Classes Scopes
        services.AddScoped<IMyEntityReadRepository, MyEntityReadRepository>();
        services.AddScoped<IMyEntityWriteRepository, MyEntityWriteRepository>();
    }
}
