using CommunityToolkit.Mvvm.DependencyInjection;
using Google.Cloud.Firestore;
using Project_Icy_Olympus.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Icy_Olympus.Models
{
    [FirestoreData()]
    public class Venue
    {
        [FirestoreProperty()]
        public string name { get; set; }
        [FirestoreProperty()]
        public string address { get; set; }
        [FirestoreProperty()]
        public BusyLevel mon { get; set; }
        [FirestoreProperty()]
        public BusyLevel tues { get; set; }
        [FirestoreProperty()]
        public BusyLevel weds { get; set; }
        [FirestoreProperty()]
        public BusyLevel thurs { get; set; }
        [FirestoreProperty()]
        public BusyLevel fri { get; set; }
        [FirestoreProperty()]
        public BusyLevel sat { get; set; }
        [FirestoreProperty()]
        public BusyLevel sun { get; set; }
        [FirestoreProperty()]
        public Vibes vibes { get; set; }
        [FirestoreProperty()]
        public long rating { get; set; }
        [FirestoreProperty()]
        public string price { get; set; }
        [FirestoreProperty()]
        public List<string> images { get; set; }
        [FirestoreProperty()]
        public Deals deals { get; set; }
        [FirestoreProperty()]
        public double lat { get; set; }
        [FirestoreProperty()]
        public double lng { get; set; }
    }

    [FirestoreData()]
    public class Vibes
    {
        [FirestoreProperty()]
        public long arcade { get; set; }
        [FirestoreProperty()]
        public long bikini { get; set; }
        [FirestoreProperty()]
        public long dancing_woman { get; set; }
        [FirestoreProperty()]
        public long dog { get; set; }
        [FirestoreProperty()]
        public long guitar { get; set; }
        [FirestoreProperty()]
        public long hearts { get; set; }
        [FirestoreProperty()]
        public long lips { get; set; }
        [FirestoreProperty()]
        public long popping_bottle { get; set; }
        [FirestoreProperty()]
        public long rainbow_flag { get; set; }
        [FirestoreProperty()]
        public long red_flag { get; set; }
        [FirestoreProperty()]
        public long shush_face { get; set; }
        [FirestoreProperty()]
        public long smoke { get; set; }
        [FirestoreProperty()]
        public long sports { get; set; }
        [FirestoreProperty()]
        public long tropical_drink { get; set; }
        [FirestoreProperty()]
        public long whiskey_glass { get; set; }
    }

    [FirestoreData()]
    public class Deals
    {
        [FirestoreProperty()]
        public Events events { get; set; }
    }

    [FirestoreData()]
    public class Events
    {
        [FirestoreProperty()]
        public List<string> drink_deals { get; set; }
        [FirestoreProperty()]
        public List<string> food_deals { get; set; }
        [FirestoreProperty()]
        public Place venue { get; set; }
    }

    [FirestoreData()]
    public class Place
    {
        [FirestoreProperty()]
        public string address { get; set; }
        [FirestoreProperty()]
        public string title { get; set; }
    }

    [FirestoreData()]
    public class BusyLevel
    {
        [FirestoreProperty()]
        public List<long> busy_hours { get; set; }
        [FirestoreProperty()]
        public DayInfo day_info { get; set; }
        [FirestoreProperty()]
        public List<long> day_raw { get; set; }
        [FirestoreProperty()]
        public List<HourAnalysis> hour_analysis { get; set; }
        [FirestoreProperty()]
        public List<PeakHours> peak_hours { get; set; }
        [FirestoreProperty()]
        public List<long> quiet_hours { get; set; }
        [FirestoreProperty()]
        public SurgeHours surge_hours { get; set; }
    }

    [FirestoreData()]
    public class PeakHours
    {
        [FirestoreProperty()]
        public long peak_delta_mean_week { get; set; }
        [FirestoreProperty()]
        public long peak_end { get; set; }
        [FirestoreProperty]
        public long peak_start { get; set; }
        [FirestoreProperty]
        public long peak_intensity { get; set; }
        [FirestoreProperty]
        public long peak_max { get; set; }
    }

    [FirestoreData()]
    public class DayInfo
    {
        [FirestoreProperty()]
        public long day_int { get; set; }
        [FirestoreProperty()]
        public long day_max { get; set; }
        [FirestoreProperty()]
        public long day_mean { get; set; }
        [FirestoreProperty()]
        public long day_rank_max { get; set; }
        [FirestoreProperty()]
        public long day_rank_mean { get; set; }
        [FirestoreProperty()]
        public string day_text { get; set; }
        [FirestoreProperty()]
        public dynamic venue_closed { get; set; }
        [FirestoreProperty()]
        public dynamic venue_open { get; set; }
    }

    [FirestoreData()]
    public class SurgeHours
    {
        [FirestoreProperty()]
        public dynamic most_people_come { get; set; }
        [FirestoreProperty()]
        public dynamic most_people_leave { get; set; }
    }

    [FirestoreData()]
    public class HourAnalysis
    {
        [FirestoreProperty()]
        public long hour { get; set; }
        [FirestoreProperty()]
        public string intensity_txt { get; set; }
        [FirestoreProperty()]
        public dynamic intensity_nr { get; set; }
    }
}
