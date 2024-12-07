var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.VisiotechTest>("visiotechtest");

builder.Build().Run();
