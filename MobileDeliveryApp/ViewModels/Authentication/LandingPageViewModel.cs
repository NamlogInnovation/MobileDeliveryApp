using MobileDeliveryApp.Services.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.ViewModels.Authentication
{
    public class LandingPageViewModel
    {
        private readonly IAuthService _authService;
        public LandingPageViewModel(IAuthService _authService)
        {

            this._authService = _authService;
            _authService.checkUserLoginDetails();
        }
    }
}
