using System.Net.Http.Headers;
using System.Text.Json;
using IdentityModel.Client;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;

const string email = "test@abp.io";
const string password = "1q2w3E*";
const string server = "https://localhost:44314/";
const string serverApi = "https://localhost:44314/api/abp/application-configuration";
// const string api = "https://localhost:44314/api/claims";
const string api = "https://localhost:44314/api/book/quote";
const string api2 = "https://localhost:44314/api/book/authors";

const string clientId = "CSP_App";
const string clientSecret = "1q2w3e*";

var client = new HttpClient();

var configuration = await client.GetDiscoveryDocumentAsync(server);
if (configuration.IsError)
{
	throw new Exception(configuration.Error);
}

var passwordTokenRequest = new PasswordTokenRequest
{
	Address = configuration.TokenEndpoint,
	ClientId = clientId,
//	ClientSecret = clientSecret,
	UserName = email,
	Password = password,
	Scope = "CSP profile roles email phone",
};
var tokenResponse = await client.RequestPasswordTokenAsync(passwordTokenRequest);

if (tokenResponse.IsError)
{
	throw new Exception(tokenResponse.Error);
}
 

var userinfo = await client.GetUserInfoAsync(new UserInfoRequest()
{
	Address = configuration.UserInfoEndpoint,
	Token = tokenResponse.AccessToken
});
if (userinfo.IsError)
{
	throw new Exception(userinfo.Error);
}

Console.WriteLine("UserInfo: {0}", JsonSerializer.Serialize(JsonDocument.Parse(userinfo.Raw), new JsonSerializerOptions
{
	WriteIndented = true
}));
Console.WriteLine();
 

var serverRequest = new HttpRequestMessage(HttpMethod.Get, serverApi);
serverRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

var serverResponse = await client.SendAsync(serverRequest);
serverResponse.EnsureSuccessStatusCode();

var dto = JsonSerializer.Deserialize<ApplicationConfigurationDto>(await serverResponse.Content.ReadAsStringAsync(), new JsonSerializerOptions()
{
	PropertyNamingPolicy = JsonNamingPolicy.CamelCase
});
Console.WriteLine("Server API response: {0}", JsonSerializer.Serialize(dto.CurrentUser, new JsonSerializerOptions
{
	WriteIndented = true
}));

Console.WriteLine();


// get quote 
var request = new HttpRequestMessage(HttpMethod.Get, api);
request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

var response = await client.SendAsync(request);
response.EnsureSuccessStatusCode();

Console.WriteLine("API response (Quote of the day): {0}", JsonSerializer.Serialize(JsonDocument.Parse(await response.Content.ReadAsStringAsync()), new JsonSerializerOptions
{
	WriteIndented = true
}));

// get authors 
try
{

	var request2 = new HttpRequestMessage(HttpMethod.Get, api2);
	request2.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

	var response2 = await client.SendAsync(request2);
	response2.EnsureSuccessStatusCode();

	Console.WriteLine("API response (Authors): {0}", await response2.Content.ReadAsStringAsync());
}catch(Exception ex)
{
	Console.WriteLine("No access !");
}

Console.WriteLine();
