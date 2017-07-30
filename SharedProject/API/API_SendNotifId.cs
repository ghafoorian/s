using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;

namespace SharedProject
{
    public class API_SendNotifId
    {
        readonly string notificationId;

        public API_SendNotifId(string NotificationId)
        {
            this.notificationId = NotificationId;
        }



        /// <summary>
        /// event Handler
        /// </summary>
        public event EventHandler<DataRecievdEventArgs> DataCallBack;



        public async Task<bool> Call()
        {


            var body = new Requests_API.SaveNotificationId();
            var namevalue = new NameValueCollection();
            namevalue.Add(body.NotificationId, notificationId);



            var data = new WebService(ApiAddresses.SaveNotificationId, namevalue, "POST");


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
            Console.WriteLine("Send Notification Id====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
            var handler = DataCallBack;
            if (e.HttpCode == HttpStatusCode.OK)
            {

                try
                {


                    if (handler == null) return;
                    handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = e.HttpCode, Data = e.Data });

                }
                catch (Exception)
                {
                    if (handler == null) return;
                    handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.Conflict, Data = e.Data });
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
        }

    }
}
