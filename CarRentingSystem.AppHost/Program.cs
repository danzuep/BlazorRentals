var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("postgres")
    .WithDataVolume();

var database = postgres.AddDatabase("car-renting-system");

builder
    .AddProject<Projects.CarRentingSystem>("carrentingsystem")
    .WithReference(database, connectionName: "DefaultConnection")
    .WaitFor(database);

builder.Build().Run();