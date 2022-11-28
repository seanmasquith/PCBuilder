using PCBuilderApp.Services;

namespace PCBuilderApp;

public partial class App : Application
{
    public static PCBuilderService PCBuilderService { get; private set; }

    public App(PCBuilderService pcBuilderService)
    {
        MainPage = new AppShell(); 
        PCBuilderService = pcBuilderService;
    }
}
