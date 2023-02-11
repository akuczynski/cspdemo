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

namespace CSP.Blazor
{
    public class ApplicationSettings : IApplicationSettings, ISingletonDependency
	{
		public const string DatabaseFilename = "CPS2SQLiteDBFile.db3";

		public const SQLite.SQLiteOpenFlags Flags =
			// open the database in read/write mode
			SQLite.SQLiteOpenFlags.ReadWrite |
			// create the database if it doesn't exist
			SQLite.SQLiteOpenFlags.Create |
			// enable multi-threaded database access
			SQLite.SQLiteOpenFlags.SharedCache;

		public string DatabaseFilePath
		{
			get
			{
				var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				return Path.Combine(basePath, DatabaseFilename);
			}
		} 
	}
}
