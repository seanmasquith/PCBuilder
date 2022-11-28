using PCBuilderApp.Services;
using PCBuilderApp.ViewModels;
using PCBuilderApp.Views;

namespace PCBuilderApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        string databasePath = "C:\\PCBuilder\\src\\PCBuilderApp\\PCBuilderApp\\SQLiteDatabase.db";

        builder.Services.AddSingleton<PCBuilderService>(s => ActivatorUtilities.CreateInstance<PCBuilderService>(s, databasePath));
        builder.Services.AddSingleton<PCBuildViewModel>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<PCBuildDetailsPage>();

		return builder.Build();
	}
}
