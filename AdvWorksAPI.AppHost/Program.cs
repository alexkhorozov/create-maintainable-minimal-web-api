var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");

builder.AddProject<Projects.AdvWorksAPI>("advworksapi")
    .WithReference(cache);

builder.Build().Run();
