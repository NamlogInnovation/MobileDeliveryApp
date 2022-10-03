using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Services.Contracts.ScanLoad
{
    public interface IScanLoadInterface
    {
        Task<bool> ScanLoad(int? loadNumberId);
    }
}
