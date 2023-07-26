using CommunityToolkit.Mvvm.ComponentModel;
using Project_Icy_Olympus.Models;
using Project_Icy_Olympus.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Icy_Olympus.ViewModels
{
    public partial class DealsPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        bool isRefreshing;

        public ObservableCollection<Venue> Venues { get; set;  } = new();
        public Command GetDealsCommand { get; }
        VenuesService venuesService;

        public DealsPageViewModel(VenuesService venuesService)
        {
            Title = "Deal Finder";
            this.venuesService = venuesService;
            GetDealsCommand = new Command(async () => await GetDealsAsync());
        }

        public async Task GetDealsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var deals = await venuesService.GetVenues();

                if (Venues.Count != 0)
                    Venues.Clear();

                foreach (var deal in deals)
                {
                    Venues.Add(deal);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Unable to get deals: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                RemoveEmptyDeals(Venues);
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        private static void RemoveEmptyDeals(ObservableCollection<Venue> Venues) {
            foreach (Venue v in Venues.ToList()) { 
                if (v.deals.events.drink_deals.Contains("NONE") || v.deals.events.food_deals.Contains("NONE"))
                {
                    Venues.Remove(v);
                }
            }
        }
    }
}
