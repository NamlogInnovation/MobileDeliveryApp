using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiPopup;
using MobileDeliveryApp.Helpers;
using MobileDeliveryApp.Helpers.PopUpPage;
using MobileDeliveryApp.Models.LastScannedLoad;
using MobileDeliveryApp.Services.Contracts.ScanLoad;
using MobileDeliveryApp.Views.WaybillInfomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static Android.Media.MediaDrm;

namespace MobileDeliveryApp.ViewModels.LastScannedLoad
{
    [QueryProperty(nameof(lastScannedLoadModel), nameof(lastScannedLoadModel))]
    public partial class LastScannedLoadViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IScanLoadInterface _scanLoadInterface;
        public LastScannedLoadViewModel(IScanLoadInterface _scanLoadInterface)
        {
            this._scanLoadInterface = _scanLoadInterface;
        }

        [ObservableProperty]
        string loggedInDriver;

        [ObservableProperty]
        string loadNumber;

        [ObservableProperty]
        public LastScannedLoadModel lastScannedLoadModel = new LastScannedLoadModel();

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            lastScannedLoadModel = (LastScannedLoadModel)query.Values.FirstOrDefault();
        }

        public async Task PopulateDriverAndLoadNumber()
        {
            LoggedInDriver = lastScannedLoadModel.LoggedInDriver;
            LoadNumber = lastScannedLoadModel.LastScannedLoadNumber.ToString();
            await Task.CompletedTask;
        }

        [RelayCommand]
        async Task ContinueWithLoad()
        {
            await PopupAction.DisplayPopup(new PopupPage());
            var response = await _scanLoadInterface.ScanLoad(Convert.ToInt32(loadNumber));
            if (response == true)
            {
                await PopupAction.ClosePopup();
                await Shell.Current.GoToAsync($"{nameof(WayBillInfoPage)}", true, new Dictionary<string, object>
                {
                    {nameof(loadNumber), loadNumber }
                });
            }
        }

        [RelayCommand]
        async Task ScanNewLoad()
        {
            await NavigationHelper.GoToScanLoadView();
        }
    }
}
