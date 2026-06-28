var builder = DistributedApplication.CreateBuilder(args);

var postgresPassword = builder.AddParameter("postgres-password", secret: true);

var postgres = builder.AddPostgres("postgres", password: postgresPassword)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume();

var mortiDb = postgres.AddDatabase("morti");

var migrationService = builder.AddProject<Projects.Morti_MigrationService>("morti-migrations")
    .WithReference(mortiDb)
    .WaitFor(mortiDb);

var apiService = builder.AddProject<Projects.Morti_API>("morti-api")
    .WithReference(mortiDb)
    .WaitFor(mortiDb)
    .WaitForCompletion(migrationService);

builder.Build().Run();
