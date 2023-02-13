using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.MainApp.Models
{
    public class MainResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public TokenResponse TokenResponse { get; set; }
    }
}
