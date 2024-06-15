using RepositoryDesignPattern.API.Context;

namespace RepositoryDesignPattern.API;

public static class SeedExtension
{
    public static async Task AddSeeder(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<RepositoryDesignPatternDbContextInitializer>();
            await initializer.InitializeAsync();
            await initializer.CreateMyEntities();

        }
    }
}
