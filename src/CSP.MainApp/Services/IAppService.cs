using CSP.MainApp.Models;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.MainApp.Services
{
    public interface IAppService
    {
       // Task<bool> RefreshToken();
         Task<MainResponse> AuthenticateUser(LoginModel loginModel);
		Task<string> GetAuthorOfTheDay();
		Task<string> GetQuoteOfTheDay();

	//    Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registerUser);
	//     Task<List<StudentModel>> GetAllStudents();
	}
}
