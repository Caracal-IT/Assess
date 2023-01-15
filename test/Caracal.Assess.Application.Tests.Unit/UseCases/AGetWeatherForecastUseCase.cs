// ReSharper disable InconsistentNaming
using Caracal.Assess.Application.Services;
using Caracal.Assess.Application.UseCases;

namespace Caracal.Assess.Application.Tests.Unit.UseCases; 

public class A_Get_Weather_Forecast_Use_Case {
  private readonly GetWeatherForecastUseCase _useCase;
  private readonly IWeatherService _weatherService;

  public A_Get_Weather_Forecast_Use_Case() {
    _weatherService = Substitute.For<IWeatherService>();
    _useCase = new GetWeatherForecastUseCase(_weatherService);
  }

  [Fact]
  public void Should_Get_Weather_Forecasts_From_Service() {
    // Arrange
    var expectedForecasts = new Model.WeatherForecast[] {
      new(Date: new DateOnly(2000, 1, 2), TemperatureInKelvin: 100, Summary: "Summary 1")
    };
    
    _weatherService.GetForecasts()
                   .Returns(expectedForecasts);
    
    // Act
    var response = _useCase.Execute(new GetWeatherForecastRequest());
    
    // Assert 
    response.Forecasts.Should().BeEquivalentTo(expectedForecasts);
  }
}