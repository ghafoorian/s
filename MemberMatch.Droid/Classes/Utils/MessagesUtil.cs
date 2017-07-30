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

namespace MemberMatch.Droid.Classes.Utils
{
    public class MessagesUtil
    {
        public static void ErrorMessage(Activity context, String message, String cancelMessage, string title)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(context);
            alert.SetMessage(message);
            alert.SetTitle(title);
            alert.SetNegativeButton(cancelMessage, (senderAlert, args) => {
            });

            AlertDialog dialog = alert.Create();
            dialog.Show();
        }
    }
}