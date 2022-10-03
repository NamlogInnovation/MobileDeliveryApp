using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MobileDeliveryApp.DataAccess.Database.DatabaseContext;
using MobileDeliveryApp.DataAccess.Database.Tables;
using MobileDeliveryApp.Models.WaybillInfomation;
using MobileDeliveryApp.Services.Contracts.WayBillInfo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Services.Implementation.WaybillInfo
{
    public class WaybillInformationService : IWaybillInformationService
    {
        private readonly IMapper _mapper;
        public WaybillInformationService(IMapper _mapper)
        {
            this._mapper = _mapper;
        }
        public async Task<ICollection<Models.WaybillInfomation.WaybillInfo>> GetWaybillInformation(int? loadNumberId)
        {
            ICollection<Models.WaybillInfomation.WaybillInfo> WaybillInfo = new List<Models.WaybillInfomation.WaybillInfo>();
            using (var _dbContext = new MobileDeliveryAppDbContext())
            {
                var waybillInfoFromDatabse = await _dbContext.WaybillInformation
                    .Where(x => x.LoadID == loadNumberId).ToListAsync();
                WaybillInfo = _mapper.Map<ICollection<Models.WaybillInfomation.WaybillInfo>>(waybillInfoFromDatabse);
                if(WaybillInfo is not null)
                {
                   return WaybillInfo;
                }
                else
                {
                    return new List<Models.WaybillInfomation.WaybillInfo>();
                }
                
            }
        }
    }
}
