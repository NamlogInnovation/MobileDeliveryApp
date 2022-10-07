using MobileDeliveryApp.ViewModels.LastScannedLoad;
using MobileDeliveryApp.ViewModels.WaybillInformation;

namespace MobileDeliveryApp.Views.LastScannedLoad;

public partial class LastScannedLoadPage : ContentPage
{
    private readonly LastScannedLoadViewModel lastScannedLoadViewModel;
    public LastScannedLoadPage(LastScannedLoadViewModel lastScannedLoadViewModel)
    {
        InitializeComponent();
        this.BindingContext = lastScannedLoadViewModel;
        this.lastScannedLoadViewModel = lastScannedLoadViewModel;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await lastScannedLoadViewModel.PopulateDriverAndLoadNumber();
    }
}