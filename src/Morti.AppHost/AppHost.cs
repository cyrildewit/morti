var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithLifetime(ContainerLifetime.Persistent);

var mortiDb = postgres.AddDatabase("morti");

var apiService = builder.AddProject<Projects.Morti_API>("morti-api")
    .WithReference(mortiDb)
    .WaitFor(mortiDb);

builder.Build().Run();
