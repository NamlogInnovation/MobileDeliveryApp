using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileDeliveryApp.Services.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.ViewModels.Authentication
{
    public partial class LandingPageViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        public LandingPageViewModel(IAuthService _authService)
        {

            this._authService = _authService;
           
        }

        [RelayCommand]
        public async Task CheckUserLoginDetails()
        {
            await _authService.checkUserLoginDetails();
        }
    }
}
