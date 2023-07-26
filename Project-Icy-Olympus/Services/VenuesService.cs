using Google.Cloud.Firestore;
using Project_Icy_Olympus.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Icy_Olympus.Services
{
    public class VenuesService
    {
        List<Venue> venueList = new();
        FirestoreDb db;

        public VenuesService()
        {
        }

        public async Task<List<Venue>> GetVenues()
        {
            if (venueList.Count > 0)
                return venueList;

            var localPath = Path.Combine(FileSystem.CacheDirectory, "icyolympustest-22a62b6cfe7e.json");
            using var json = await FileSystem.OpenAppPackageFileAsync("icyolympustest-22a62b6cfe7e.json");
            using var dest = File.Create(localPath);
            await json.CopyToAsync(dest);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", localPath);
            dest.Close();
            this.db = FirestoreDb.Create("icyolympustest");

            CollectionReference places = db.Collection("Venues");
            QuerySnapshot allDeals = await places.GetSnapshotAsync();
            Debug.WriteLine(allDeals.ToString());

            if (allDeals != null)
            {
                foreach (DocumentSnapshot document in allDeals.Documents)
                {
                    Venue venue = document.ConvertTo<Venue>();
                    venueList.Add(venue);
                }
            }

            return venueList;
        }
    }
}
