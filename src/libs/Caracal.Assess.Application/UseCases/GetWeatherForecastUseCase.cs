// ReSharper disable ClassNeverInstantiated.Global
using Caracal.Assess.Application.Services;

namespace Caracal.Assess.Application.UseCases;

public sealed class GetWeatherForecastUseCase: IGetWeatherForecastUseCase {
  private readonly IWeatherService _weatherService;
  
  public GetWeatherForecastUseCase(IWeatherService weatherService) =>
    _weatherService = weatherService;

  public GetWeatherForecastResponse Execute(GetWeatherForecastRequest request) =>
    new (Forecasts: _weatherService.GetForecasts().Select(MapForecasts));

  private static WeatherForecast MapForecasts(Model.WeatherForecast forecast) =>
    new (
      Date: forecast.Date,
      TemperatureInKelvin: forecast.TemperatureInKelvin,
      Summary: forecast.Summary
    );
}