using Caracal.Assess.Api.Models;
using Caracal.Assess.Application.UseCases;

namespace Caracal.Assess.Api.Handlers; 

public static class GetWeatherHandler {
  public static Func<IGetWeatherForecastUseCase, CancellationToken, IEnumerable<WeatherForecastViewModel>> Handle() => 
    (useCase, cancellation) =>
      useCase.Execute(new GetWeatherForecastRequest())
        .Forecasts
        .Select(forecast => new WeatherForecastViewModel {
          Date = forecast.Date,
          TemperatureC = forecast.TemperatureInKelvin - 273,
          Summary = forecast.Summary
        });
}