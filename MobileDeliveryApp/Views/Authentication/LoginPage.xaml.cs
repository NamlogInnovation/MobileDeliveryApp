using MobileDeliveryApp.ViewModels.Authentication;

namespace MobileDeliveryApp.Views.Authentication;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
        this.BindingContext = loginViewModel;
    }
}