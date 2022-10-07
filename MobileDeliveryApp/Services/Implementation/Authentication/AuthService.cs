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
using System.Security.Cryptography;
using MobileDeliveryApp.DataAccess.Database.Tables;
using AutoMapper;
using MobileDeliveryApp.DataAccess.Database.DatabaseContext;
using MobileDeliveryApp.Models.WaybillInfomation;
using Microsoft.EntityFrameworkCore;
using MobileDeliveryApp.Models.LastScannedLoad;
using MobileDeliveryApp.Views.WaybillInfomation;
using MobileDeliveryApp.Views.LastScannedLoad;
using MauiPopup;

namespace MobileDeliveryApp.Services.Implementation.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        public AuthService(IMapper _mapper)
        {
            this._mapper = _mapper;
        }
        public async Task checkUserLoginDetails()
        {
            try
            {
                var token = await SecureStorage.GetAsync("Token");
                if (string.IsNullOrEmpty(token))
                {
                    await NavigationHelper.GoToLoginPage();
                }
                else
                {
                    var jsonToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
                    var loggedInUserFromToken = jsonToken.Claims.FirstOrDefault(x => x.Type.Equals("displayname")).Value;

                    if (jsonToken.ValidTo < DateTime.UtcNow)
                    {
                        SecureStorage.Remove("Token");
                        await NavigationHelper.GoToLoginPage();
                    }
                    else
                    {
                        await GetLastLoadAndUserDetails(loggedInUserFromToken);
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return;
            }

        }

        private async Task GetLastLoadAndUserDetails(string loggedInUserDriver)
        {
            var lastScannedLoadModel = new LastScannedLoadModel();
            using (var _dbContext = new MobileDeliveryAppDbContext())
            {
                var lastScannedLoad = await _dbContext.WaybillInformation
                    .OrderByDescending(x => x.Id)
                    .Select(x => x.LoadID)
                    .FirstOrDefaultAsync();

                if (lastScannedLoad is null)
                {
                    //Incase there is a popup action that is still in use
                    await PopupAction.ClosePopup();
                    await NavigationHelper.GoToScanLoadView();
                }
                else
                {
                    lastScannedLoadModel.LoggedInDriver = loggedInUserDriver;
                    lastScannedLoadModel.LastScannedLoadNumber = (int)lastScannedLoad;
                    //Incase there is a popup action that is still in use
                    await PopupAction.ClosePopup();
                    await Shell.Current.GoToAsync($"{nameof(LastScannedLoadPage)}", true, new Dictionary<string, object>
                    {
                        {nameof(lastScannedLoadModel), lastScannedLoadModel }
                    });
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
                        if (authResponse.data.jwToken is null)
                        {
                            return false;
                        }
                        else
                        {
                            await SecureStorage.SetAsync("Token", authResponse.data.jwToken);
                            var jsonToken = new JwtSecurityTokenHandler().ReadToken(authResponse.data.jwToken) as JwtSecurityToken;
                            var loggedInUserFromToken = jsonToken.Claims.FirstOrDefault(x => x.Type.Equals("displayname")).Value;
                            await GetLastLoadAndUserDetails(loggedInUserFromToken);
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
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

        public string DescryptLoginScanTagToken(string key, string loginScanTagToken)
        {
            try
            {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(loginScanTagToken);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;
            }

        }

        public async Task<bool> LoginThroughScanTag(EmployeeModel employee)
        {
            try
            {
                using (var _dbContext = new MobileDeliveryAppDbContext())
                {
                    var employeeRecord = await _dbContext.Employee.Where(x => x.IdNumber == employee.IdNumber &&
                    x.ScanTagToken == employee.ScanTagToken).FirstOrDefaultAsync();

                    if (employeeRecord is not null)
                    {
                        await GetLastLoadAndUserDetails(employeeRecord.Firstname + " " + employeeRecord.LastName);
                        return true;
                    }
                    else
                    {
                        var mappedEmployeeModel = _mapper.Map<Employee>(employee);
                        await _dbContext.Employee.AddAsync(mappedEmployeeModel);
                        await _dbContext.SaveChangesAsync();
                        await GetLastLoadAndUserDetails(mappedEmployeeModel.Firstname + " " + mappedEmployeeModel.LastName);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }

        }
    }
}

