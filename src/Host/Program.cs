var builder = DistributedApplication.CreateBuilder(args);

// Add our "api" weather forecast service
var api = builder.AddJavaScriptApp("api", "../Api", "start")
                 .WithHttpEndpoint(env: "PORT");

// Add our "app" frontend and depend on the "api"
builder.AddJavaScriptApp("app", "../App", "start")
       .WithReference(api)
       .WaitFor(api)
       .WithEnvironment("BROWSER", "none")
       .WithHttpEndpoint(env: "PORT");

builder.Build().Run();