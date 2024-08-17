using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.API.Abstractions;
using RepositoryDesignPattern.API.Concretes;
using RepositoryDesignPattern.API.Context;

namespace RepositoryDesignPattern.API;

public static class ServiceExtension
{
    private static readonly string _connectionStr = @"Server=WINDOWS-BL2EM9B\SQLEXPRESS;Database=RepositoryDesignPatternDB;Trusted_Connection=True;TrustServerCertificate=True;";
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
