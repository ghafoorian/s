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
using Android.Support.V7.App;
using SharedProject;
using MemberMatch.Droid.Classes.Utils;
using SharedProject.Classes;

namespace MemberMatch.Droid.Classes.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : AppCompatActivity
    {
        TextView mUsernameLabel, mPasswordLabel;
        EditText mUsername, mPassword;
        CheckBox mRememberCheckBox;
        Button mSignIn, mForgor;
        ProgressBar mProgressBar;
        Intent intent;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            InitializeVariable();                     
        }

        public void InitializeVariable()
        {
            mUsernameLabel = FindViewById<TextView>(Resource.Id.username_label);
            mPasswordLabel = FindViewById<TextView>(Resource.Id.password_label);
            mUsername = FindViewById<EditText>(Resource.Id.username_etxt);
            mPassword = FindViewById<EditText>(Resource.Id.password_etxt);
            mRememberCheckBox = FindViewById<CheckBox>(Resource.Id.rememberMe_cbox);
            mSignIn = FindViewById<Button>(Resource.Id.sign_in_btn);
            mForgor = FindViewById<Button>(Resource.Id.forgot_btn);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressbar);

            mRememberCheckBox.Selected = UserHolder.RememberMe;
            if (UserHolder.RememberMe)
            {
                mUsername.Text = UserHolder.UserName;
                mPassword.Text = UserHolder.PassWord;
            }
            mSignIn.Click += SignIn_Btn_Clicked;
            mForgor.Click += Forgot_Btn_Clicked;
            mProgressBar.Visibility = ViewStates.Gone;
        }

        private void Forgot_Btn_Clicked(object sender, EventArgs e)
        {
            Android.Net.Uri weburi = Android.Net.Uri.Parse(AppGlobal.Server.Address + "Account/ForgotPassword");
            var webintent = new Intent(Intent.ActionView, weburi);
            StartActivity(webintent);
        }

        async void SignIn_Btn_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(mUsername.Text) || string.IsNullOrEmpty(mPassword.Text))
            {
                MessagesUtil.ErrorMessage(this, GetString(Resource.String.empty_data), GetString(Resource.String.ok), "");
                return;
            }

            if (UserHolder.UserName != mUsername.Text)
                UserHolder.DeleteAllData();

            UserHolder.UserName = mUsername.Text;
            UserHolder.PassWord = mPassword.Text;
            UserHolder.RememberMe = mRememberCheckBox.Selected;
            UserHolder.DefaultServer = "8060";

            if (ConnectionNetworkUtil.CheckConnection(this.BaseContext))
            {
                mProgressBar.Visibility = ViewStates.Visible;
                var login = new API_Login(mUsername.Text, mPassword.Text);
                login.DataCallBack += Login_DataCallBack;
                await login.Call();
            }else
            {
                MessagesUtil.ErrorMessage(this, GetString(Resource.String.no_network), GetString(Resource.String.ok), "");
            }
        }

         void Login_DataCallBack(object sender, API_Login.DataRecievdEventArgs e)
        {
            RunOnUiThread(() =>
            {
                mProgressBar.Visibility = ViewStates.Gone;
                if (!ConnectionNetworkUtil.CheckConnection(this.BaseContext))
                    MessagesUtil.ErrorMessage(this, GetString(Resource.String.no_network), GetString(Resource.String.ok), "");
                else
                {
                    if (e.Status)
                    {
                      //  SendNotifId();
                        StartActivity(new Intent(this, typeof(ProfileActivity)));
                    }
                    else if (e.HttpCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessagesUtil.ErrorMessage(this, GetString(Resource.String.check_data), GetString(Resource.String.ok), "");                      
                    }
                    else
                    {
                        MessagesUtil.ErrorMessage(this, e.Data, GetString(Resource.String.ok), "");                       
                    }
                }
            });
        }

        async void SendNotifId()
        {

            string playerId = "";

            //OneSignal.Current.IdsAvailable((playerID, pushToken) =>
            //{
            //    playerId = playerID;
            //});

            Console.WriteLine("Playerid==> " + playerId);

            var sendNotif = new API_SendNotifId(playerId);
            await sendNotif.Call();


        }
    }
}