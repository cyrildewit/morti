using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Morti.Infrastructure.Data;

namespace Morti.Infrastructure;

public static class DependencyInjection
{
    private const string DatabaseConnectionName = "morti";

    public static TBuilder AddInfrastructure<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        var connectionString = builder.Configuration.GetConnectionString(DatabaseConnectionName);

        builder.Services.AddDbContext<MortiDbContext>(options =>
            options.UseNpgsql(connectionString));

        builder.EnrichNpgsqlDbContext<MortiDbContext>();

        return builder;
    }
}
