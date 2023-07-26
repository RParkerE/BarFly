using CommunityToolkit.Maui;
using Mopups.Hosting;
using Mopups.Interfaces;
using Mopups.Services;
using Project_Icy_Olympus.Services;
using Project_Icy_Olympus.ViewModels;
using Project_Icy_Olympus.Views;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Project_Icy_Olympus;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureMopups()
			.UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("FontAwesome.ttf", "FontAwesome");
            });

        builder.Services.AddTransient<MapPage>();
        builder.Services.AddTransient<DealsPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<SignUpPage>();
        builder.Services.AddTransient<ProfilePage>();

        builder.Services.AddTransient<MapPageViewModel>();
        builder.Services.AddTransient<DealsPageViewModel>();
		builder.Services.AddTransient<LoginPageViewModel>();
		builder.Services.AddTransient<SignUpPageViewModel>();

        builder.Services.AddSingleton<AuthService>();
        builder.Services.AddSingleton<RegisterService>();
        builder.Services.AddTransient<VenuesService>();

        builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);

        return builder.Build();
	}
}
