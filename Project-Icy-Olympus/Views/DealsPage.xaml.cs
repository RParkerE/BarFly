using CommunityToolkit.Maui.Alerts;
using Project_Icy_Olympus.ViewModels;
using CommunityToolkit.Maui.Core;

namespace Project_Icy_Olympus.Views;

public partial class DealsPage : ContentPage
{
	public DealsPage(DealsPageViewModel dealsPageViewModel)
	{
		InitializeComponent();
        BindingContext = dealsPageViewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await (BindingContext as DealsPageViewModel).GetDealsAsync();
    }
}