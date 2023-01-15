using CSP.Settings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.MainApp
{
    public class ApplicationSettings : IApplicationSettings, ISingletonDependency
	{
		public const string DatabaseFilename = "CPS2SQLiteDBFile.db3";

        public string DatabaseFilePath =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DatabaseFilename);
    }
} 