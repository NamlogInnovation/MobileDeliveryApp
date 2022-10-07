using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileDeliveryApp.Helpers;
using MobileDeliveryApp.Models.WaybillInfomation;
using MobileDeliveryApp.Services.Contracts.WayBillInfo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobileDeliveryApp.ViewModels.WaybillInformation
{
    [QueryProperty(nameof(loadNumber), nameof(loadNumber))]
    public partial class WayBillInfoViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IWaybillInformationService _waybillInformationService;
        private readonly IMapper _mapper;
        public ObservableCollection<WaybillInfo> WaybillInfo { get; private set; } = new();
        public WayBillInfoViewModel(IWaybillInformationService _waybillInformationService,
            IMapper _mapper)
        {
            this._waybillInformationService = _waybillInformationService;
            this._mapper = _mapper;
        }

        [ObservableProperty]
        int? loadNumber;

        [ObservableProperty]
        string deliveryType;

        [ObservableProperty]
        string customer;

        [ObservableProperty]
        string waybillNo;

        [ObservableProperty]
        string date;

        [ObservableProperty]
        string completedStatus;

        
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            loadNumber = Convert.ToInt32(HttpUtility.UrlDecode(query["loadNumber"].ToString()));
        }


        [RelayCommand]
        public async Task GetWayBillInformation()
        {
            try
            {
                var waybillInformation = await _waybillInformationService.GetWaybillInformation(loadNumber);
                foreach (var info in waybillInformation)
                {
                    WaybillInfo.Add(info);
                }
                if (WaybillInfo is not null)
                {
                    foreach (var waybillInfo in WaybillInfo)
                    {
                        deliveryType = waybillInfo.DeliveryType;
                        customer = waybillInfo.Customer;
                        waybillNo = waybillInfo.WaybillNo;
                        date = waybillInfo.Date;
                        completedStatus = waybillInfo.Completed;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return;
            }
        }

        [RelayCommand]
        async Task Logout()
        {
            SecureStorage.Remove("Token");
            await NavigationHelper.GoToLoginPage();
        }
    }
}
