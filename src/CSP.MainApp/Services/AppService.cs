using CSP.MainApp.Models;
using IdentityModel.Client;
using Newtonsoft.Json;
using Scriban.Runtime.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.MainApp.Services
{
    public class AppService : IAppService
    {
        public async Task<MainResponse> AuthenticateUser(LoginModel loginModel)
        {
            var response = new MainResponse();

            using (var client = new HttpClient())
            {
                var url = $"{Setting.BaseUrl}{APIs.Token}";     // change this to auhorize 
                string clientId = "CSP_App";

                var passwordTokenRequest = new PasswordTokenRequest
                {
                    Address = url,
                    ClientId = clientId,
                    //	ClientSecret = clientSecret,
                    UserName = loginModel.Email,
                    Password = loginModel.Password,
                    Scope = "CSP profile roles email phone",
                };
                var tokenResponse = await client.RequestPasswordTokenAsync(passwordTokenRequest);

                if (tokenResponse.IsError)
                {
                    return new MainResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = tokenResponse.Error
                    }; 
                }
                
                return new MainResponse
                {
                    IsSuccess = true,
                    TokenResponse = tokenResponse
                };
            } 
        }

        public async Task<string> GetAuthorOfTheDay()
		{
			string returnResponse = null;
			using (var client = new HttpClient())
			{
				var url = $"{Setting.BaseUrl}{APIs.AuthorOfTheDay}";

				client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Setting.UserBasicDetail?.AccessToken}");
				var response = await client.GetAsync(url);

				if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
				{
					//bool isTokenRefreshed = await RefreshToken();
					//if (isTokenRefreshed) return await GetAllStudents();
				}

				else
				{
					if (response.IsSuccessStatusCode)
					{
						returnResponse = await response.Content.ReadAsStringAsync();
					}
					else
					{
						returnResponse = "** Forbidden **";
					}
				}

			}
			return returnResponse;
		}

		public async Task<string> GetQuoteOfTheDay()
		{
			string returnResponse = null;
			using (var client = new HttpClient())
			{
				var url = $"{Setting.BaseUrl}{APIs.QuoteOfTheDay}";

				client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Setting.UserBasicDetail?.AccessToken}");
				var response = await client.GetAsync(url);

				if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
				{
					//bool isTokenRefreshed = await RefreshToken();
					//if (isTokenRefreshed) return await GetAllStudents();
				}

				else
				{
					if (response.IsSuccessStatusCode)
					{
						returnResponse = await response.Content.ReadAsStringAsync();
					}
					else
					{
						returnResponse = "** Forbidden **";
					}
				}

			}
			return returnResponse;
		}

		//public async Task<bool> RefreshToken()
		//{
		//    bool isTokenRefreshed = false;
		//    using (var client = new HttpClient())
		//    {
		//        var url = $"{Setting.BaseUrl}{APIs.RefreshToken}";

		//        var serializedStr = JsonConvert.SerializeObject(new AuthenticateRequestAndResponse
		//        {
		//            RefreshToken = Setting.UserBasicDetail.RefreshToken,
		//            AccessToken = Setting.UserBasicDetail.AccessToken
		//        });

		//        try
		//        {
		//            var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
		//            if (response.IsSuccessStatusCode)
		//            {
		//                string contentStr = await response.Content.ReadAsStringAsync();
		//                var mainResponse = JsonConvert.DeserializeObject<MainResponse>(contentStr);
		//                if (mainResponse.IsSuccess)
		//                {
		//                    var tokenDetails = JsonConvert.DeserializeObject<AuthenticateRequestAndResponse>(mainResponse.Content.ToString());
		//                    Setting.UserBasicDetail.AccessToken = tokenDetails.AccessToken;
		//                    Setting.UserBasicDetail.RefreshToken = tokenDetails.RefreshToken;

		//                    string userDetailsStr = JsonConvert.SerializeObject(Setting.UserBasicDetail);
		//                    await SecureStorage.SetAsync(nameof(Setting.UserBasicDetail), userDetailsStr);
		//                    isTokenRefreshed = true;
		//                }
		//            }
		//        }
		//        catch (Exception ex)
		//        {
		//            string msg = ex.Message;
		//        }


		//    }
		//    return isTokenRefreshed;
		//} 
	}
}
