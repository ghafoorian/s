using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using System.Threading.Tasks;

using SharedProject;

using MemberMatch.Droid.Classes.Constants;
using Android.Support.V7.App;

namespace MemberMatch.Droid.Classes.Activities
{
    [Activity( MainLauncher = true, Theme = "@style/SplashStyle", ScreenOrientation = ScreenOrientation.Portrait, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            UserHolder.CreateOrOpenDatabase(UserHolder.DefaultDbPath, UserHolder.DefaultDbName);

           // OneSignal.Current.StartInit(GlobalInstants.OneSignalID).EndInit();
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => {
                Task.Delay(500);
            });

            startupWork.ContinueWith(t => {
                
                    StartActivity(new Intent(this, typeof(ProfileActivity)));
                Finish();
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }
    }
}