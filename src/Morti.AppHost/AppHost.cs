var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Morti_API>("morti-api");

builder.Build().Run();
