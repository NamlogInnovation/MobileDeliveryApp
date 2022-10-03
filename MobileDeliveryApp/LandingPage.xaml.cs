using MobileDeliveryApp.ViewModels.Authentication;

namespace MobileDeliveryApp;

public partial class LandingPage : ContentPage
{
	public LandingPage(LandingPageViewModel landingPageViewModel)
	{
		InitializeComponent();
        this.BindingContext = landingPageViewModel;
    }
}