var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddNpmApp("api", "../Api")
                 .WithNpmPackageInstallation()
                 .WithHttpEndpoint(env: "PORT");

builder.AddNpmApp("app", "../App")
       .WithNpmPackageInstallation()
       .WithReference(api)
       .WaitFor(api)
       .WithEnvironment("BROWSER", "none")
       .WithHttpEndpoint(env: "PORT");

builder.Build().Run();