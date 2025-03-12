using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class AutomatedMigration
{
    public static async Task MigrateAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<AudiobookDbContext>();

        if (context.Database.IsNpgsql())
            await context.Database.MigrateAsync();
    }
}
