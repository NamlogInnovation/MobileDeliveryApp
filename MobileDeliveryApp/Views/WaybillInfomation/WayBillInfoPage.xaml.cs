using MobileDeliveryApp.ViewModels.WaybillInformation;

namespace MobileDeliveryApp.Views.WaybillInfomation;

public partial class WayBillInfoPage : ContentPage
{
    private readonly WayBillInfoViewModel wayBillInfoViewModel;
    public WayBillInfoPage(WayBillInfoViewModel wayBillInfoViewModel)
    {
        InitializeComponent();
        this.BindingContext = wayBillInfoViewModel;
        this.wayBillInfoViewModel = wayBillInfoViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await wayBillInfoViewModel.GetWayBillInformation();
    }
}