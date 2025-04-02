using AutoMapper;
using EasyTravel.Solution.Contracts.Interfaces;
using EasyTravel.Solution.Services;
using EasyTravel.Solution.ThirdPartyConnections;
using EasyTravel.Solution.ThirdPartyConnections.Contracts;
using EasyTravel.Solution.ThirdPartyConnections.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IApiProxy, ApiProxy>();
builder.Services.AddScoped<HttpClient, HttpClient>();

var mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new MapperProfile()));
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

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
