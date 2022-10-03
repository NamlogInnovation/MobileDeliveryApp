using MobileDeliveryApp.Models.WaybillInfomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Services.Contracts.WayBillInfo
{
    public interface IWaybillInformationService
    {
        Task<ICollection<Models.WaybillInfomation.WaybillInfo>> GetWaybillInformation(int? loadNumberId);
    }
}
