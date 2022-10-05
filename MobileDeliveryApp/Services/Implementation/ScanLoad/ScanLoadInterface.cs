using MobileDeliveryApp.Services.Api;
using MobileDeliveryApp.Models.ScanLoad;
using MobileDeliveryApp.Services.Contracts.Authentication;
using MobileDeliveryApp.Services.Contracts.ScanLoad;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MobileDeliveryApp.DataAccess.Database.Tables;
using MobileDeliveryApp.DataAccess.Database.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MobileDeliveryApp.Services.Implementation.ScanLoad
{
    public class ScanLoadInterface : IScanLoadInterface
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public ScanLoadInterface(IAuthService _authService,
            IMapper _mapper)
        {
            this._authService = _authService;
            this._mapper = _mapper;
        }
        public async Task<bool> ScanLoad(int? loadNumberId)
        {
            try
            {
                if (loadNumberId == 0 || loadNumberId is null)
                {
                    return false;
                }
                else
                {
                    ICollection<WaybillInformation> waybillInfo = new List<WaybillInformation>();
                    using (var _dbContext = new MobileDeliveryAppDbContext())
                    {
                        waybillInfo = await _dbContext.WaybillInformation.Where(x => x.LoadID == loadNumberId).ToListAsync();
                    }

                    if (waybillInfo is null || waybillInfo.Count == 0)
                    {
                        await _authService.SetAuthToken();

                        var apiResponse = await ApiService._MobileDeliveryApiClient.GetStringAsync("/api/v1/Integrations/mobile/load/" + (int)loadNumberId);

                        _authService.RemoveRequestHeaders();

                        if (apiResponse is not null)
                        {
                            var waybillInformation = JsonConvert.DeserializeObject<ScannedLoadWaybill>(apiResponse);
                            if (waybillInformation.data.Count() != 0)
                            {
                                var mappedWaybillInfo = _mapper.Map<IEnumerable<WaybillInformation>>(waybillInformation.data);
                                using (var _dbContext = new MobileDeliveryAppDbContext())
                                {
                                    foreach (var WaybillInfo in mappedWaybillInfo)
                                    {
                                        await _dbContext.WaybillInformation.AddAsync(WaybillInfo);
                                        await _dbContext.SaveChangesAsync();
                                    }
                                }
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }
        }
    }
}
