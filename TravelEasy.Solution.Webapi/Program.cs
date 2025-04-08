using AutoMapper;
using EasyTravel.Solution.Cache.Services;
using EasyTravel.Solution.Contracts.Interfaces;
using EasyTravel.Solution.Services;
using EasyTravel.Solution.ThirdPartyConnections.Contracts;
using EasyTravel.Solution.ThirdPartyConnections.MappingProfiles;
using EasyTravel.Solution.ThirdPartyConnections.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IApiProxy, ApiProxy>();
builder.Services.AddScoped<IAirportsAndCityService, AirportsAndCityService>();
builder.Services.AddScoped<HttpClient, HttpClient>();

var mapperConfiguration = new MapperConfiguration(mc =>
{
    mc.AddProfile(new DestinationsFromOriginMapperProfile());
    mc.AddProfile(new FlightOfferMapperProfile());
});
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "redis-server:";
});
builder.Services.AddScoped<ICacheService, RedisService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
