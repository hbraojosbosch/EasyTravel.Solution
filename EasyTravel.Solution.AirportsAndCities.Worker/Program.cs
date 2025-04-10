using EasyTravel.Solution.AirportsAndCities.Worker;
using EasyTravel.Solution.Cache.Services;
using EasyTravel.Solution.Contracts.Interfaces;
using EasyTravel.Solution.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<AirportsAndCitiesLoderWorker>();

builder.Services.AddScoped<IAirportsAndCityService, AirportsAndCityService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<HttpClient, HttpClient>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "redis-server:";
});
builder.Services.AddScoped<ICacheService, RedisService>();

var host = builder.Build();
host.Run();
