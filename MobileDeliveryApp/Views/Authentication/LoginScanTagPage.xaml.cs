using MobileDeliveryApp.ViewModels.Authentication;

namespace MobileDeliveryApp.Views.Authentication;

public partial class LoginScanTagPage : ContentPage
{
    public LoginScanTagPage(LoginScanTagViewModel loginScanTagViewModel)
    {
        InitializeComponent();
        this.BindingContext = loginScanTagViewModel;
    }
}