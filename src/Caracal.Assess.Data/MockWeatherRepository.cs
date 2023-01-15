using Caracal.Assess.Application.Model;
using Caracal.Assess.Application.Repositories;

namespace Caracal.Assess.Data; 

public class MockWeatherRepository: IWeatherRepository {
  private static readonly string[] Summaries = {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
  };


  public IEnumerable<WeatherForecast> GetForecasts() =>
    Enumerable.Range(1, 5)
              .Select(CreateFromIndex);
  
  private static WeatherForecast CreateFromIndex(int index) =>
    new (
      Date: DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
      TemperatureInKelvin: Random.Shared.Next(-20, 55) + 273,
      Summary: Summaries[Random.Shared.Next(Summaries.Length)]
    );
}