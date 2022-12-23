using CSP.WebGate;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace CSP.Services
{

    public class ServiceModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
		}


        public Dictionary<object, string> GetServices()
        {
            var result = new Dictionary<object, string>();

            //            result.Add()

            return result;
        }

    }
}