using Caracal.Assess.Api.Handlers;
using Caracal.Assess.Api.Models;
using Caracal.Assess.Application.Repositories;
using Caracal.Assess.Application.Services;
using Caracal.Assess.Application.UseCases;
using Caracal.Assess.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
       .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.Authority = "https://localhost:5443";
           options.Audience = "weatherapi";

           options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
       });

builder.Services.AddAuthorization();

// Dependency Injection for now
builder.Services.AddSingleton<IGetWeatherForecastUseCase, GetWeatherForecastUseCase>();
builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.AddSingleton<IWeatherRepository, MockWeatherRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/weatherforecast", GetWeatherHandler.Handle())
   .Produces<IEnumerable<WeatherForecastViewModel>>()
   .WithName("GetWeatherForecast")
   .RequireAuthorization(policy => policy.RequireClaim("scope", "weatherapi.read"))
   //.RequireAuthorization()
   .WithOpenApi();

app.Run();