using Mapsui;
using Mopups.Interfaces;
using Mopups.Pages;
using Mopups.Services;
using Project_Icy_Olympus.Models;
using System.Diagnostics;

namespace Project_Icy_Olympus.Views;

public partial class VenuePopup : PopupPage
{
	IFeature? pInfo;
    public VenuePopup(IFeature? pInfo)
	{
		InitializeComponent();
        this.pInfo = pInfo;
		string info = this.pInfo["name"].ToString() + "\n" + this.pInfo["address"].ToString() + "\n" + this.pInfo["ratings"].ToString() + "\n" + this.pInfo["price"].ToString() + "\n" + this.pInfo["vibes"].ToString();
        Info.Text = info;
    }

    async void OnButtonClicked(object sender, EventArgs args)
    {
        await MopupService.Instance.PushAsync(new VibeVotePopup());
    }
}