namespace Caracal.Assess.Application.Services;

public interface IWeatherService {
  IEnumerable<Model.WeatherForecast> GetForecasts();
}