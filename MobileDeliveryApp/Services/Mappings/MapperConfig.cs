using AutoMapper;
using MobileDeliveryApp.DataAccess.Database.Tables;
using MobileDeliveryApp.Models.ScanLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Services.Mappings
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Data, WaybillInformation>().ReverseMap();
        }
    }
}
