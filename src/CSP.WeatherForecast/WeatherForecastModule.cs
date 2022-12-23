using Volo.Abp;
using Volo.Abp.Modularity;

namespace CSP.WeatherForecast
{

    public class WeatherForecastModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            //var myService = context.ServiceProvider
            //    .GetRequiredService<TeamService>();

            //myService.Initialize();
        }
    }
}