var builder = DistributedApplication.CreateBuilder(args);

var myCache = builder.AddRedis("cache")
    .WithImageRegistry("ghcr.io")
    .WithImage("microsoft/garnet")
    .WithImageTag("latest");

var myApi = builder.AddProject<Projects.Api>("api")
    .WithReference(myCache);

var web = builder.AddProject<Projects.MyWeatherHub>("myweatherhub")
    .WithReference(myApi)
    .WithExternalHttpEndpoints();

builder.Build().Run();
