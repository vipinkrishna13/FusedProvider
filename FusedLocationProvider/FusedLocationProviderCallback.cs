using System;
using System.Linq;

using Android.Gms.Location;
using Android.Util;

namespace com.xamarin.samples.location.fusedlocationprovider
{
    public class FusedLocationProviderCallback : LocationCallback
    {
        readonly MainActivity activity;
        FileLogger fileLogger;

        public FusedLocationProviderCallback(MainActivity activity)
        {
            this.activity = activity;
            fileLogger = new FileLogger();
        }

        public override void OnLocationAvailability(LocationAvailability locationAvailability)
        {
            Log.Debug("FusedLocationProviderSample", "IsLocationAvailable: {0}",locationAvailability.IsLocationAvailable);
        }


        public override void OnLocationResult(LocationResult result)
        {
            if (result.Locations.Any())
            {
                var location = result.Locations.First();
                activity.latitude2.Text = activity.Resources.GetString(Resource.String.latitude_string, location.Latitude);
                activity.longitude2.Text = activity.Resources.GetString(Resource.String.longitude_string, location.Longitude);
                activity.speed2.Text = activity.Resources.GetString(Resource.String.speed_string, location.Speed*3.6);
                activity.provider2.Text = activity.Resources.GetString(Resource.String.requesting_updates_provider_string, location.Provider);
                fileLogger.LogInformation($"{DateTime.Now} - Lat: {location.Latitude} , Long: {location.Longitude} , Speed: {location.Speed * 3.6}");
            }
            else
            {
                activity.latitude2.SetText(Resource.String.location_unavailable);
                activity.longitude2.SetText(Resource.String.location_unavailable);
                activity.speed2.SetText(Resource.String.location_unavailable);
                activity.provider2.SetText(Resource.String.could_not_get_last_location);
                activity.requestLocationUpdatesButton.SetText(Resource.String.request_location_button_text);
            }
        }
    }
}
