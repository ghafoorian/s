using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;



namespace SharedProject
	{
	public class API_GetCourseStatus
		{
		readonly string courseid;

		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataCallBack;


		public API_GetCourseStatus(string Courseid)
			{
			this.courseid = Courseid;
			}


		public async Task<bool> Call()
			{
			var body = new Requests_API.CourseStatus();

			var namevalue = new NameValueCollection();
			namevalue.Add(body.courseid, courseid);

			var data = new WebService(ApiAddresses.CourseStatus, namevalue, "GET");

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
			Console.WriteLine("Course Status ====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
			var handler = DataCallBack;
			if (e.HttpCode == HttpStatusCode.OK)
				{

				try
					{

					var notes = JToken.Parse(e.Data).SelectToken("notes").ToString();
					var isOpened = JToken.Parse(e.Data).SelectToken("isOpened").ToString();
					var buggies = JToken.Parse(e.Data).SelectToken("buggies").ToString();
					var trolleys = JToken.Parse(e.Data).SelectToken("trolleys").ToString();
					var range = JToken.Parse(e.Data).SelectToken("range").ToString();
					var electricTrolleys = JToken.Parse(e.Data).SelectToken("electricTrolleys").ToString();
					var manualTrolleys = JToken.Parse(e.Data).SelectToken("manualTrolleys").ToString();
					var winterWheels = JToken.Parse(e.Data).SelectToken("winterWheels").ToString();
					var dateTime = JToken.Parse(e.Data).SelectToken("dateTime").ToString();

					if (handler == null) return;
						handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = HttpStatusCode.NoContent, Data = e.Data,
						Notes=notes,IsOpened=isOpened,Buggies=buggies,Trolleys=trolleys,Range=range,ElectricTrolleys=electricTrolleys,
						ManualTrolleys=manualTrolleys,WinterWheels=winterWheels,DateTime=dateTime});

					}
				catch (Exception)
					{
					if (handler == null) return;
							handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.NoContent, Data =e.Data });
					}

				}
			else
				{
				if (handler == null) return;
						handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = e.HttpCode, Data =e.Data });
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

			public string Notes { get; set;}
			public string IsOpened { get; set;}
			public string Buggies { get; set;}
			public string Trolleys { get; set;}
			public string Range { get; set;}
			public string ElectricTrolleys { get; set;}
			public string ManualTrolleys { get; set;}
			public string WinterWheels { get; set;}
			public string DateTime { get; set;}

			}
		}
	}

