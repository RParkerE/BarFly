using CommunityToolkit.Mvvm.ComponentModel;
using Mapsui.UI.Maui;
using Mapsui.Tiling;
using Project_Icy_Olympus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapsui.Projections;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Styles;
using Project_Icy_Olympus.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SkiaSharp;
using Color = Mapsui.Styles.Color;
using Mapsui.UI;
using Mopups.Interfaces;
using Project_Icy_Olympus.Views;

namespace Project_Icy_Olympus.ViewModels
{
    public partial class MapPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        MapControl myMap;
        [ObservableProperty]
        bool isRefreshing;
        public ObservableCollection<Venue> Venues { get; } = new();
        IPopupNavigation popupNavigation;
        public Command GetPlacesCommand { get; }
        VenuesService venuesService;
        private static List<CalloutStyle> calloutlist = new List<CalloutStyle>();

        public MapPageViewModel(VenuesService venuesService, IPopupNavigation popupNavigation)
        {
            Title = "Maps";
            this.venuesService = venuesService;
            this.popupNavigation = popupNavigation;
            GetPlacesCommand = new Command(async () => await GetPlacesAsync());
        }

        public async Task GetPlacesAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var places = await venuesService.GetVenues();

                if (Venues.Count != 0)
                    Venues.Clear();

                foreach (var place in places)
                    Venues.Add(place);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                MyMap = new MapControl();
                MyMap.Map?.Layers.Add(OpenStreetMap.CreateTileLayer());
                MyMap.Map?.Layers.Add(CreatePointLayer());
                var atxLocation = new MPoint(-97.7404, 30.2747);
                var sphericalMercatorCoordinate = SphericalMercator.FromLonLat(atxLocation.X, atxLocation.Y).ToMPoint();
                MyMap.Map.Navigator.CenterOnAndZoomTo(sphericalMercatorCoordinate, 14);
                MyMap.Map.Info += MapOnInfo;

                IsBusy = false;
                IsRefreshing = false;
            }
        }
        //private static void MapOnInfo(object? sender, MapInfoEventArgs e)
        //{
        //    var calloutStyle = e.MapInfo?.Feature?.Styles.Where(s => s is CalloutStyle).Cast<CalloutStyle>().FirstOrDefault();
        //    if (calloutStyle != null)
        //    {
        //        calloutlist.Add(calloutStyle);
        //        foreach (var callout in calloutlist)
        //        {
        //            callout.Enabled = false;
        //        }
        //        calloutStyle.Enabled = !calloutStyle.Enabled;
        //        e.MapInfo?.Layer?.DataHasChanged(); // To trigger a refresh of graphics.
        //    }
        //    if (calloutlist.Count > 1)
        //        calloutlist.RemoveRange(0, calloutlist.Count - 1);
        //}
        private void MapOnInfo(object? sender, MapInfoEventArgs e)
        {
            var calloutStyle = e.MapInfo?.Feature?.Styles.Where(s => s is CalloutStyle).Cast<CalloutStyle>().FirstOrDefault();
            //var pInfo = e.MapInfo?.Feature.ToStringOfKeyValuePairs();
            var pInfo = e.MapInfo?.Feature;
            if (calloutStyle != null)
            {
                calloutlist.Add(calloutStyle);
                foreach (var callout in calloutlist)
                { 
                    callout.Enabled = false;
                }
                calloutStyle.Enabled = !calloutStyle.Enabled;
                popupNavigation.PushAsync(new VenuePopup(pInfo));
                e.MapInfo?.Layer?.DataHasChanged(); // To trigger a refresh of graphics.
            }
            if (calloutlist.Count > 1)
                calloutlist.RemoveRange(0, calloutlist.Count - 1);
        }

        private MemoryLayer CreatePointLayer()
        {
            return new MemoryLayer
            {
                Name = "Points",
                IsMapInfoLayer = true,
                Features = new Mapsui.Providers.MemoryProvider(GetPlacesFromList()).Features,
                Style = SymbolStyles.CreatePinStyle() //<- Reference for custom marker: https://github.com/Mapsui/Mapsui/blob/master/Samples/Mapsui.Samples.Common/Maps/Callouts/CustomCalloutSample.cs#L64
            };
        }

        private IEnumerable<IFeature> GetPlacesFromList()
        {
            var venues = Venues;

            return venues.Select(p => {
                var feature = new PointFeature(SphericalMercator.FromLonLat(p.lng, p.lat).ToMPoint());
                //Add busy levels, vibes, etc here
                feature["name"] = p.name;
                feature["address"] = p.address;
                /*feature["mon"] = p.mon;
                feature["tues"] = p.tues;
                feature["weds"] = p.weds;
                feature["thurs"] = p.thurs;
                feature["fri"] = p.fri;
                feature["sat"] = p.sat;
                feature["sun"] = p.sun;*/
                feature["vibes"] = p.vibes;
                feature["ratings"] = p.rating;
                feature["price"] = p.price;
                feature["deals"] = p.deals;
                var calloutStyle = CreateCalloutStyle();
                feature.Styles.Add(calloutStyle);
                return feature;
            });
        }

        private static CalloutStyle CreateCalloutStyle()
        {
            return new CalloutStyle
            {
                MaxWidth = 0,
                RectRadius = 10,
                ShadowWidth = 0,
                Enabled = false,
                SymbolOffset = new Offset(0, 0)
            };
        }
    }
}
