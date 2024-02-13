using GameStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtensions
{
    public static async Task InitializedDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GamestoreContext>();
        await dbContext.Database.MigrateAsync();
    }

    public static IServiceCollection AddRepsoitories(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connString = configuration.GetConnectionString("GameStoreContext");
        services.AddDbContext<GamestoreContext>(options => options.UseSqlServer(connString))
                .AddScoped<IGameRepository, EntityFrameworkGamesRepository>();
        return services;
    }
}


