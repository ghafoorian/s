using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;


namespace SharedProject
{
    public class API_CreateGame
    {

        /// <summary>
        /// event Handler
        /// </summary>
        public event EventHandler<DataRecievdEventArgs> DataCallBack;

        readonly NameValueCollection postData;

        public API_CreateGame(NameValueCollection postData)
        {
            this.postData = postData;
        }

        public async Task<bool> Call()
        {

            var data = new WebService(ApiAddresses.CreateMatch, postData, "POST");


            data.DataRecieved += Data_DataRecieved;

            await data.Connect();

            return false;


        }

        /// <summary>
        /// Datas the data recieved.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Data_DataRecieved(object sender, SharedProject.WebService.DataRecievdEventArgs e)
        {
            Console.WriteLine("Create a Game ===>  " + e.Status + " " + e.HttpCode + " " + e.Data);
            var handler = DataCallBack;
            if (e.HttpCode == HttpStatusCode.OK)
            {

                try
                {

                    var gameCode = JToken.Parse(e.Data).SelectToken("matchNumber").ToString();
                    var gameId = JToken.Parse(e.Data).SelectToken("matchId").ToString();

                    if (handler == null) return;
                    handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = e.HttpCode, Data = e.Data, MatchNumber = gameCode, MatchId = gameId });

                }
                catch (Exception ex)
                {
                    if (handler == null) return;
                    handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = e.HttpCode, Data = e.Data });
                }
            }
            else
            {
                if (handler == null) return;
                handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = e.HttpCode, Data = e.Data });
            }
        }


        /// <summary>
        /// EventArgs
        /// </summary>
        public class DataRecievdEventArgs : EventArgs
        {
            public bool Status
            {
                get;
                set;
            }

            public HttpStatusCode HttpCode
            {
                get;
                set;
            }

            public string Data
            {
                get;
                set;
            }

            public string MatchNumber
            {
                get;
                set;
            }

            public string MatchId
            {
                get;
                set;
            }
        }

    }
}
