namespace Caracal.Assess.Application.Repositories; 

public interface IWeatherRepository {
  IEnumerable<Model.WeatherForecast> GetForecasts();
}