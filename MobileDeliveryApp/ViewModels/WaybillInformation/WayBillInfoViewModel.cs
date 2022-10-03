using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileDeliveryApp.Models.WaybillInfomation;
using MobileDeliveryApp.Services.Contracts.WayBillInfo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.ViewModels.WaybillInformation
{
    public partial class WayBillInfoViewModel : ObservableObject
    {
        private readonly IWaybillInformationService waybillInformationService;
        public ObservableCollection<WaybillInfo> WaybillInfo { get; private set; }
        public WayBillInfoViewModel(IWaybillInformationService waybillInformationService)
        {
            this.waybillInformationService = waybillInformationService;
        }

        [ObservableProperty]
        int? loadIdNumber = null;

        [RelayCommand]

    }
}
