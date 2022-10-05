using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiPopup;
using MobileDeliveryApp.Helpers.PopUpPage;
using MobileDeliveryApp.Services.Contracts.Authentication;
using MobileDeliveryApp.Services.Contracts.ScanLoad;
using MobileDeliveryApp.Services.Implementation.Authentication;
using MobileDeliveryApp.Views.ScanLoad;
using MobileDeliveryApp.Views.WaybillInfomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.ViewModels.ScanLoad
{
    public partial class ScanLoadViewModel : ObservableObject
    {

        private readonly IScanLoadInterface _scanLoadInterface;

        public ScanLoadViewModel(IScanLoadInterface _scanLoadInterface)
        {
            this._scanLoadInterface = _scanLoadInterface;
        }

        [ObservableProperty]
        int? loadNumber = null;

        [ObservableProperty]
        string loadMessage;

        [RelayCommand]
        async Task ScanLoad()
        {
            await PopupAction.DisplayPopup(new PopupPage());
            var response = await _scanLoadInterface.ScanLoad(loadNumber);
            if (response == true)
            {
                LoadMessage = string.Empty;
                await PopupAction.ClosePopup();
                await Shell.Current.GoToAsync($"{nameof(WayBillInfoPage)}", true, new Dictionary<string, object>
                {
                    {nameof(loadNumber), loadNumber }
                });

            }
            else
            {
                await PopupAction.ClosePopup();
                LoadMessage = "Invalid load number";
                await Shell.Current.DisplayAlert("Result", "Something went wrong. Please scan or enter a valid load number." +
                    " If the problem persists kindly contact IT Support", "Ok");
            }

        }
    }
}
