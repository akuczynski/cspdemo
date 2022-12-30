using CSP.ModuleContracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.MainApp
{
    public class ApplicationSettings : IApplicationSettings, ISingletonDependency
	{
        public ApplicationSettings(IConfiguration configuration) {
            DatabaseFilename = configuration.GetValue<string>("DatabaseFilename");
        }    

        public string DatabaseFilename { get; init; }
         
        public string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
