using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SharedProject
	{
	public class API_PlayNow
		{
		readonly string locationId;
		readonly string activeFor;
		readonly bool isWaitingForAPlayer;

		public API_PlayNow(string LocationId, string ActiveFor, bool IsWaitingForAPlayer)
			{
			this.isWaitingForAPlayer = IsWaitingForAPlayer;
			this.activeFor = ActiveFor;
			this.locationId = LocationId;
			}


		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataCallBack;



		public async Task<bool> Call()
			{

			var body = new Requests_API.PlayNow();

			var postData = new NameValueCollection();
			postData.Add(body.LocationId,locationId);
			postData.Add(body.ActiveFor,activeFor);
			postData.Add(body.IsWaitingForAPlayer,isWaitingForAPlayer.ToString());


			var data = new WebService(ApiAddresses.PlayNow, postData, "POST");


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
			Console.WriteLine("Play Now ===>  " + e.Status + " " + e.HttpCode + " " + e.Data);
			var handler = DataCallBack;
			if (e.HttpCode == HttpStatusCode.OK)
				{

				try
					{

					if (handler == null) return;
					handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = e.HttpCode});

					}
				catch (Exception)
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

			}

		}
	}
