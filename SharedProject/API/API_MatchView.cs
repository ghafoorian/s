using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace SharedProject
{
    public class API_MatchView

    {

        readonly string matchId;
        readonly string matchNumber;

        public API_MatchView(string matchId, string matchNumber)
        {
            this.matchId = matchId;
            this.matchNumber = matchNumber;
        }

        /// <summary>
        /// event Handler
        /// </summary>
        public event EventHandler<DataRecievdEventArgs> DataCallBack;

        public async Task<bool> Call()
        {

            var body = new Requests_API.MatchView();

            var namevalue = new NameValueCollection();
            namevalue.Add(body.MatchId, matchId);
            namevalue.Add(body.MatchNumber, matchNumber);



            var data = new WebService(ApiAddresses.MatchView, namevalue, "GET");


            data.DataRecieved += Data_DataRecieved;


            await data.Connect();

            return false;


        }

        private List<GameView_Model> playerList = new List<GameView_Model>();

        /// <summary>
        /// Datas the data recieved.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Data_DataRecieved(object sender, SharedProject.WebService.DataRecievdEventArgs e)
        {
            Console.WriteLine("MatchView====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
            var handler = DataCallBack;
            if (e.HttpCode == HttpStatusCode.OK)
            {



                try
                {
                    var jsonObject = JToken.Parse(e.Data);
                    if (jsonObject is JArray)
                    {

                        playerList = JsonConvert.DeserializeObject<List<GameView_Model>>(e.Data);
                    }
                    else
                    {
                        e.Data += "]";
                        e.Data = "[" + e.Data;
                        playerList = JsonConvert.DeserializeObject<List<GameView_Model>>(e.Data);

                    }



                }
                catch (Exception)
                {
                    if (handler == null) return;
                    handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.Conflict, Data = new List<GameView_Model>() });
                }

                if (handler == null) return;
                handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = e.HttpCode, Data = playerList });
            }
            else
            {
                if (handler == null) return;
                handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = e.HttpCode, Data = new List<GameView_Model>() });
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

            public List<GameView_Model> Data
            {
                get;
                set;
            }
        }
    }
}
