using AutoMapper;
using MobileDeliveryApp.DataAccess.Database.Tables;
using MobileDeliveryApp.Models.Authentication;
using MobileDeliveryApp.Models.ScanLoad;
using MobileDeliveryApp.Models.WaybillInfomation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Services.Mappings
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Models.ScanLoad.Data, WaybillInformation>().ReverseMap();
            CreateMap<ObservableCollection<WaybillInfo>, ICollection<WaybillInfo>>().ReverseMap();
            CreateMap<WaybillInfo, WaybillInformation>().ReverseMap();
            CreateMap<Employee, EmployeeModel>().ReverseMap();


        }
    }
}
