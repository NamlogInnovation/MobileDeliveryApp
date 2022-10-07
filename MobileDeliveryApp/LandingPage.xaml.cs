using MobileDeliveryApp.Services.Contracts.Authentication;
using MobileDeliveryApp.ViewModels.Authentication;

namespace MobileDeliveryApp;

public partial class LandingPage : ContentPage
{
    private readonly LandingPageViewModel landingPageViewModel;
    public LandingPage(LandingPageViewModel landingPageViewModel)
    {
        InitializeComponent();
        this.BindingContext = landingPageViewModel;
        this.landingPageViewModel = landingPageViewModel;
    }

    protected override async void OnAppearing()
    {
        await landingPageViewModel.CheckUserLoginDetails();
    }
}