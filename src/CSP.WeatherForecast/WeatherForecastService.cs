using CSP.ModuleContracts;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;

namespace CSP.WeatherForecast;

internal class WeatherForecastService : IWeatherForecastService, ITransientDependency
{
	private readonly ILogger<WeatherForecastService> _logger;

	public WeatherForecastService(ILogger<WeatherForecastService> logger)
	{
		_logger = logger;
	}

	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	public Task<CSP.ModuleContracts.WeatherForecast[]> GetForecastAsync(DateTime startDate)
	{
		return Task.FromResult(Enumerable.Range(1, 5).Select(index => new CSP.ModuleContracts.WeatherForecast
        {
			Date = startDate.AddDays(index),
			TemperatureC = Random.Shared.Next(-20, 55),
			Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		}).ToArray());
	}
}

