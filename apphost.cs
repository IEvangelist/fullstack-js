#:sdk Aspire.AppHost.Sdk@13.0.0
#:package Aspire.Hosting.JavaScript@13.0.0

var builder = DistributedApplication.CreateBuilder(args);

// Add our "api" weather forecast service
var api = builder.AddJavaScriptApp("api", "./src/api", "start")
    .WithHttpEndpoint(env: "PORT");

// Add our "frontend" and depend on the "api"
builder.AddJavaScriptApp("frontend", "./src/frontend", "start")
    .WithExternalHttpEndpoints()
    .WithReference(api)
    .WaitFor(api)
    .WithEnvironment("BROWSER", "none")
    .WithHttpEndpoint(env: "PORT");

builder.Build().Run();
