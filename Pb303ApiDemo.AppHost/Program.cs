var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Rahat_API>("rahat-api");

builder.Build().Run();
