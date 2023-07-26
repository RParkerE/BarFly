using MonkeyCache.FileStore;

namespace Project_Icy_Olympus;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//Barrel.ApplicationId = AppInfo.PackageName;

		MainPage = new AppShell();
	}
}
