using EasyTravel.Solution.AirportsAndCities.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<AirportsAndCitiesLoderWorker>();

var host = builder.Build();
host.Run();
