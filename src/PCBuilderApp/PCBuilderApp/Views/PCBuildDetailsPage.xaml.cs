using PCBuilderApp.ViewModels;

namespace PCBuilderApp.Views;

public partial class PCBuildDetailsPage : ContentPage
{
	public PCBuildDetailsPage(PCBuildDetailsViewModel pcBuildDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = pcBuildDetailsViewModel;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}
}