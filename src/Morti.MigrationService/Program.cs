using Morti.Infrastructure;
using Morti.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.AddInfrastructure();

builder.Services.AddHostedService<MortiDbInitializer>();

var host = builder.Build();

host.Run();
