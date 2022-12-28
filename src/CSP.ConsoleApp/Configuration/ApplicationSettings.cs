using CSP.ModuleContracts;
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
        public string DatabaseFilename = "CSPSQLite.db3";

        //public const SQLite.SQLiteOpenFlags Flags =
        //    // open the database in read/write mode
        //    SQLite.SQLiteOpenFlags.ReadWrite |
        //    // create the database if it doesn't exist
        //    SQLite.SQLiteOpenFlags.Create |
        //    // enable multi-threaded database access
        //    SQLite.SQLiteOpenFlags.SharedCache;

        public string DatabasePath =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DatabaseFilename);
    }
}
