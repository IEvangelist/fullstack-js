var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddNpmApp("api", "../api")
                 .WithNpmPackageInstallation()
                 .WithHttpEndpoint(env: "PORT");

builder.AddNpmApp("app", "../app")
       .WithNpmPackageInstallation()
       .WithReference(api)
       .WaitFor(api)
       .WithEnvironment("BROWSER", "none")
       .WithHttpEndpoint(env: "PORT");

builder.Build().Run();