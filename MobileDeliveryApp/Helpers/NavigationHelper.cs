using MobileDeliveryApp.Views.Authentication;
using MobileDeliveryApp.Views.ScanLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Helpers
{
    public static class NavigationHelper
    {
        public static async Task GoToLoginPage()
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }

        public static async Task GoToScanLoadView()
        {
            await Shell.Current.GoToAsync($"{nameof(ScanLoadPage)}");
        }
    }
}
