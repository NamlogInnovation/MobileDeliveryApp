using MobileDeliveryApp.DataAccess.Database.Tables;
using MobileDeliveryApp.Models.Authentication;
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
        string DescryptLoginScanTagToken(string key, string loginScanTagToken);

        Task<bool> LoginThroughScanTag(EmployeeModel employee);
    }
}
