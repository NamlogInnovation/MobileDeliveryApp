using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Services.Api
{
    public class ApiService
    {
        public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://fmsintegrations.namlog.co.za/api" :
           "https://fmsintegrations.namlog.co.za/api";

        public static HttpClient _MobileDeliveryApiClient = new HttpClient
        {
            BaseAddress = new Uri(BaseAddress)
        };
    }
}
