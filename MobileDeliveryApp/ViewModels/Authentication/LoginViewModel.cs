using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiPopup;
using MobileDeliveryApp.Helpers;
using MobileDeliveryApp.Helpers.PopUpPage;
using MobileDeliveryApp.Services.Contracts.Authentication;
using MobileDeliveryApp.Views.Authentication;
using MobileDeliveryApp.Views.LastScannedLoad;
using MobileDeliveryApp.Views.ScanLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.ViewModels.Authentication
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        public LoginViewModel(IAuthService _authService)
        {
            this._authService = _authService;
        }

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string loginMessage;

        [RelayCommand]
        async Task Login()
        {
            await PopupAction.DisplayPopup(new PopupPage());
            var loginResponse = await _authService.Login(username, password);
            if (loginResponse == false)
            {
                await PopupAction.ClosePopup();
                LoginMessage = "Invalid username or password";
                Password = String.Empty;
                await AuthenticationMessages.DisplayLoginMessage("Invalid Login Attempt. Please try again. " +
                    "If the problem persists try to login by scanning the QR code on your tag otherwise contact IT support");
            }
            else
            {
                Username = String.Empty;
                Password = String.Empty;
                return;
            }
        }

        [RelayCommand]
        async Task GoToLoginScanTagePage()
        {
            await Shell.Current.GoToAsync($"{nameof(LoginScanTagPage)}", true);
        }
    }
}
