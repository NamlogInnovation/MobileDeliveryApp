using MobileDeliveryApp.Models.Authentication;

namespace MobileDeliveryApp;

public partial class App : Application
{
    public static UserInfo UserInfo;
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
