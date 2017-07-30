using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace SharedProject
{
    public class API_GetClubEvents
    {
        readonly string eventType;
        readonly string endDate;
        readonly string startday;


        /// <summary>
        /// event Handler
        /// </summary>
        public event EventHandler<DataRecievdEventArgs> DataCallBack;


        public API_GetClubEvents(string Startday, string EndDate, string EventType)
        {
            this.startday = Startday;
            this.endDate = EndDate;
            this.eventType = EventType;
        }


        public async Task<bool> Call()
        {
            var body = new Requests_API.ClubEvents();

            var namevalue = new NameValueCollection();
            namevalue.Add(body.UserId, "");
            namevalue.Add(body.StartDate, startday);
            namevalue.Add(body.EndDate, endDate);
            namevalue.Add(body.EventType, eventType);

            var data = new WebService(ApiAddresses.ClubEvents, namevalue, "GET");

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
            Console.WriteLine("Get ClubEvents ====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
            var handler = DataCallBack;
            if (e.HttpCode == HttpStatusCode.OK)
            {

                try
                {
                    if (e.Data != "[]")
                    {

                        UserHolder.ClubEvents = e.Data;

                        var List = JToken.Parse(e.Data).SelectToken("").ToString();

                        var eventsList = JsonConvert.DeserializeObject<List<ClubEvents_Model>>(List);

                        if (handler == null) return;
                        handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = HttpStatusCode.NoContent, Data = eventsList });


                    }
                    else
                    {
                        if (handler == null) return;
                        handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.NoContent, Data = new List<ClubEvents_Model>() });
                    }
                }
                catch (Exception)
                {
                    if (handler == null) return;
                    handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.NoContent, Data = new List<ClubEvents_Model>() });
                }

            }
            else
            {
                if (handler == null) return;
                handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = e.HttpCode, Data = new List<ClubEvents_Model>() });
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

            public List<ClubEvents_Model> Data
            {
                get;
                set;
            }
        }
    }
}
