using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;

namespace com.xamarin.samples.location.fusedlocationprovider
{
    [Service]
    public class ForegroundService : Service
    {
      //  ILocationHelper locationHelper;

        public ForegroundService()
        {
          //  locationHelper = DependencyService.Get<ILocationHelper>();
        }

        public override void OnCreate()
        {
            base.OnCreate();

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var CHANNEL_ID = "my_channel_01";
                NotificationChannel channel = new NotificationChannel(CHANNEL_ID, "Channel human readable title", NotificationImportance.Default);

                ((NotificationManager)GetSystemService(Context.NotificationService)).CreateNotificationChannel(channel);

                Notification notification = new NotificationCompat.Builder(this, CHANNEL_ID)
                        .SetContentTitle("Copiloto")
                        .SetContentText("App is running...").Build();

                StartForeground(1, notification);
            }
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            base.OnStartCommand(intent, flags, startId);


          //  locationHelper.Start();
            // This tells Android not to restart the service if it is killed to reclaim resources.
            return StartCommandResult.Sticky;
        }


        public override void OnDestroy()
        {

            // We need to shut things down.
            base.OnDestroy();

            StopSelf();
        }

 
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }
}
