using MobileDeliveryApp.ViewModels.ScanLoad;

namespace MobileDeliveryApp.Views.ScanLoad;

public partial class ScanLoadPage : ContentPage
{
	public ScanLoadPage(ScanLoadViewModel scanLoadViewModel)
	{
		InitializeComponent();
		this.BindingContext = scanLoadViewModel;
	}
}