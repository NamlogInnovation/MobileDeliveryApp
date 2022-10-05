using MobileDeliveryApp.Views.Authentication;
using MobileDeliveryApp.Views.ScanLoad;
using MobileDeliveryApp.Views.WaybillInfomation;

namespace MobileDeliveryApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(ScanLoadPage), typeof(ScanLoadPage));
        Routing.RegisterRoute(nameof(WayBillInfoPage), typeof(WayBillInfoPage));
        Routing.RegisterRoute(nameof(LoginScanTagPage), typeof(LoginScanTagPage));



    }

    protected override bool OnBackButtonPressed()
    {
        return false;
    }
}
