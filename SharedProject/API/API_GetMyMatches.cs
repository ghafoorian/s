using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace SharedProject
{
    public class API_GetMyMatches
    {
        readonly string startday;
        readonly string endDate;
        readonly string matchOptions;

        public API_GetMyMatches(string Startday, string EndDate, string MatchOptions)
        {
            this.matchOptions = MatchOptions;
            this.endDate = EndDate;
            this.startday = Startday;
        }

        /// <summary>
        /// event Handler
        /// </summary>
        public event EventHandler<DataRecievdEventArgs> DataCallBack;


        public async Task<bool> Call()
        {
            var body = new Requests_API.MyMatches();

            var namevalue = new NameValueCollection();
            namevalue.Add(body.StartDate, startday);
            namevalue.Add(body.EndDate, endDate);
            namevalue.Add(body.Options, matchOptions);

            var data = new WebService(ApiAddresses.MyMatches, namevalue, "GET");

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
            Console.WriteLine("Get MyMatches ====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
            var handler = DataCallBack;
            if (e.HttpCode == HttpStatusCode.OK)
            {

                try
                {
                    if (e.Data != "[]")
                    {

                        UserHolder.MyMatches = e.Data;

                        var List = JToken.Parse(e.Data).SelectToken("").ToString();

                        var eventsList = JsonConvert.DeserializeObject<List<GameView_Model>>(List);

                        if (handler == null) return;
                        handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = HttpStatusCode.NoContent, Data = eventsList });


                    }
                    else
                    {
                        if (handler == null) return;
                        handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.NoContent, Data = new List<GameView_Model>() });
                    }
                }
                catch (Exception)
                {
                    if (handler == null) return;
                    handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.NoContent, Data = new List<GameView_Model>() });
                }

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
