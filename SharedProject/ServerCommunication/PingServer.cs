using System.Text.RegularExpressions;
using System.Threading.Tasks;
#if __IOS__
using MemberMatch.iOS;
#endif
using Plugin.Connectivity;


namespace SharedProject
{
    public class PingServer
    {
        readonly string url;


        public enum PingResult
        {
            Ok,
            Disconnect,
            ServerErr,
        };

        public PingServer (string url)
        {
			const string port = ":";
			const string sep = "/";

            if (url.Contains ("https://")) {
                url = url.Replace ("https://", "");
                var urls = Regex.Split (url, sep);
                url = urls [0];
            }

            if (url.Contains ("http://")) {
                url = url.Replace ("http://", "");
                var urls = Regex.Split (url, sep);
                url = urls [0];

            }

			if (url.Contains(":")){
				var urls = Regex.Split(url, port);
				url = urls[0];
			}

            this.url = url;
        }

        public async Task<PingResult> Test ()
        {
            //  string result;
			var connected = CrossConnectivity.Current.IsConnected;

            if (connected) {
                var connect = await CrossConnectivity.Current.IsRemoteReachable (url, 80, 8000);

                if (!connect)
                {
#if __IOS__
                    ShowMessage.InternetError();
#endif
                }
                return connect ? PingResult.Ok : PingResult.ServerErr;

            } else {
#if __IOS__
                ShowMessage.InternetError ();
#endif
                return PingResult.Disconnect;
            }


        }

    }
}