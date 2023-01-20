namespace Caracal.Assess.Application.UseCases;

public record GetWeatherForecastResponse(IEnumerable<WeatherForecast> Forecasts){}