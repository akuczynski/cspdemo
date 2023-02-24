using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.MainApp.Models
{
    internal class Setting
    {
        public static UserBasicDetail UserBasicDetail { get; set; }

        public const string BaseUrl = "https://df45-89-239-124-15.eu.ngrok.io"; // "https://localhost:44314"; 

		// Tip: When you use Ngrok.exe remember to shutdown eScaler  
	}
}
