using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;



namespace SharedProject
	{
	public class API_GetActivePlayNow
		{


		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataCallBack;

		public API_GetActivePlayNow()
			{
			}


		public async Task<bool> Call()
			{

			var data = new WebService(ApiAddresses.ActivePlayNow);

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
			Console.WriteLine("Active Play Now ===>  " + e.Status + " " + e.HttpCode + " " + e.Data);
			var handler = DataCallBack;
			if (e.HttpCode == HttpStatusCode.OK)
				{

				try
					{

					var playList = JToken.Parse(e.Data).SelectToken("").ToString();


					var playNow = JsonConvert.DeserializeObject<List<PlayNow_Model>>(playList);

					if (handler == null) return;
					handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = e.HttpCode, PlayNowUsers = playNow });

					}
				catch (Exception)
					{
					if (handler == null) return;
					handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = e.HttpCode, Data = e.Data, PlayNowUsers = new List<PlayNow_Model>() });
					}
				}
			else
				{
				if (handler == null) return;
				handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = e.HttpCode, Data = e.Data, PlayNowUsers = new List<PlayNow_Model>() });
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

			public List<PlayNow_Model> PlayNowUsers { get; set; }

			}

		}
	}
