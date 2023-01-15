// ReSharper disable ClassNeverInstantiated.Global
using Caracal.Assess.Application.Repositories;

namespace Caracal.Assess.Application.Services;

public interface IWeatherService {
  IEnumerable<Model.WeatherForecast> GetForecasts();
}

public sealed class WeatherService: IWeatherService {
  private readonly IWeatherRepository _weatherRepository;

  public WeatherService(IWeatherRepository weatherRepository) =>
    _weatherRepository = weatherRepository;
  
  public IEnumerable<Model.WeatherForecast> GetForecasts() =>
    _weatherRepository.GetForecasts();
}