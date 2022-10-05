using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiPopup;
using MobileDeliveryApp.Helpers;
using MobileDeliveryApp.Helpers.PopUpPage;
using MobileDeliveryApp.Models.Authentication;
using MobileDeliveryApp.Services.Contracts.Authentication;
using MobileDeliveryApp.Views.ScanLoad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.ViewModels.Authentication
{
    public partial class LoginScanTagViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        public LoginScanTagViewModel(IAuthService _authService)
        {
            this._authService = _authService;
        }

        [ObservableProperty]
        string loginMessage;

        [ObservableProperty]
        string scanTagToken;


        [RelayCommand]
        public async Task LoginThroughTagScan()
        {
            await PopupAction.DisplayPopup(new PopupPage());
            var response = _authService.DescryptLoginScanTagToken("BF96BF5816B04B0996A54A5D3D3BBD9a", scanTagToken);

            var employeeLoggedIn = JsonConvert.DeserializeObject<EmployeeModel>(response);
            employeeLoggedIn.ScanTagToken = scanTagToken;

            var loginResponse = await _authService.LoginThroughScanTag(employeeLoggedIn);
            if (loginResponse == true)
            {
                await PopupAction.ClosePopup();
                await Shell.Current.GoToAsync($"{nameof(ScanLoadPage)}", true);
            }
            else
            {
                await PopupAction.ClosePopup();
                LoginMessage = "Invalid scan or Unauthorized user";
                ScanTagToken = string.Empty;
                await AuthenticationMessages.DisplayLoginMessage("Invalid Login Attempt. Please try again. " +
                    "If the problem persists contact IT support");
            }

        }
    }
}
