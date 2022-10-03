using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Helpers
{
    public static class AuthenticationMessages
    {
        public static async Task DisplayLoginMessage(string message)
        {
            await Shell.Current.DisplayAlert("Login Result", message, "Ok");
        }
    }
}
