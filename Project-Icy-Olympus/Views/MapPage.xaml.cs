using Mopups.Pages;
using Mopups.Services;
using Project_Icy_Olympus.ViewModels;

namespace Project_Icy_Olympus.Views;

public partial class MapPage : ContentPage
{
	public MapPage(MapPageViewModel mapPageViewModel)
	{
		InitializeComponent();
        BindingContext = mapPageViewModel;

        //Content = mapPageViewModel.MyMap;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        //await MopupService.Instance.PushAsync(new VenuePopup());
        await (BindingContext as MapPageViewModel).GetPlacesAsync();
    }
}