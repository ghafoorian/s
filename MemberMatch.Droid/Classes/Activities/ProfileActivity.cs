using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace MemberMatch.Droid.Classes.Activities
{
    [Activity(Label = "MainActivity", Icon = "@drawable/icon")]
    public class ProfileActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView(Resource.Layout.activity_profile);
        }
    }
}

