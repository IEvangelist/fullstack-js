var builder = DistributedApplication.CreateBuilder(args);

// Add our "api" weather forecast service


// Add our "app" frontend and depend on the "api"


builder.Build().Run();