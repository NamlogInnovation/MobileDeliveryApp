using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Services.Contracts.Authentication
{
    public interface IAuthService
    {
        Task<bool> Login(string username, string password);
        Task checkUserLoginDetails();

        Task SetAuthToken();

        void RemoveRequestHeaders();
    }
}
