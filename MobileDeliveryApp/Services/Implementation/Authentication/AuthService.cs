using MobileDeliveryApp.Services.Api;
using MobileDeliveryApp.Helpers;
using MobileDeliveryApp.Models.Authentication;
using MobileDeliveryApp.Services.Contracts.Authentication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Services.Implementation.Authentication
{
    public class AuthService : IAuthService
    {
        public async Task checkUserLoginDetails()
        {
            var token = await SecureStorage.GetAsync("Token");

            if (string.IsNullOrEmpty(token))
            {
                await NavigationHelper.GoToLoginPage();

            }
            else
            {
                var jsonToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
                if (jsonToken.ValidTo < DateTime.UtcNow)
                {
                    SecureStorage.Remove("Token");
                    await NavigationHelper.GoToLoginPage();
                }
                else
                {
                    await NavigationHelper.GoToScanLoadView();
                }
            }
        }

        public async Task<bool> Login(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    return false;
                }
                else
                {
                    var loginModel = new LoginModel()
                    {
                        Username = username.Trim(),
                        Password = password.Trim()
                    };

                    var response = await ApiService._MobileDeliveryApiClient.PostAsJsonAsync("/api/Accounts/Authenticate", loginModel);

                    if (response.IsSuccessStatusCode)
                    {
                        var authResponse = JsonConvert.DeserializeObject<AuthResponseModel>(await response.Content.ReadAsStringAsync());
                        await SecureStorage.SetAsync("Token", authResponse.data.jwToken);
                        var jsonToken = new JwtSecurityTokenHandler().ReadToken(authResponse.data.jwToken) as JwtSecurityToken;
                        App.UserInfo = new UserInfo()
                        {
                            Username = username,
                            Role = jsonToken.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value
                        };

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return false;
            }
        }
        public async Task SetAuthToken()
        {

            var token = await SecureStorage.GetAsync("Token");
            ApiService._MobileDeliveryApiClient.DefaultRequestHeaders.Add("ClientId", "LMSW!ndows@pp");
            ApiService._MobileDeliveryApiClient.DefaultRequestHeaders.Add("ClientSecret", "79C020A2-9B97-4736-B6B3-BBDB6DF32512");
            ApiService._MobileDeliveryApiClient.DefaultRequestHeaders.Authorization = new
                System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        }

        public void RemoveRequestHeaders()
        {
            ApiService._MobileDeliveryApiClient.DefaultRequestHeaders.Remove("ClientId");
            ApiService._MobileDeliveryApiClient.DefaultRequestHeaders.Remove("ClientSecret");
        }


    }
}
