using HtmlAgilityPack;
using PCBuilderApp.ViewModels;
using System.Linq;
using System.Web;

namespace PCBuilderApp;

public partial class MainPage : ContentPage
{
	public MainPage(PCBuildViewModel pcBuildViewModel)
	{
		InitializeComponent();
        BindingContext = pcBuildViewModel;
	}
}