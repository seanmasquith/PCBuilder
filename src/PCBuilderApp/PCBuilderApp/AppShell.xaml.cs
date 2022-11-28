using PCBuilderApp.Views;

namespace PCBuilderApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(PCBuildDetailsPage), typeof(PCBuildDetailsPage));
	}
}
