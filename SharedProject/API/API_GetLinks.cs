using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharedProject
	{
	public class API_GetLinks
		{
		public API_GetLinks()
			{
			}


		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataCallBack;

		public async Task<bool> Call()
			{

			var body = new Requests_API.GetLinks();

			var namevalue = new System.Collections.Specialized.NameValueCollection();
			namevalue.Add(body.loggedUserId, UserHolder.UserId);


			var data = new WebService(ApiAddresses.GetLinks, namevalue, "GET");


			data.DataRecieved += Data_DataRecieved;


			await data.Connect();

			return false;


			}


		private List<GolfLinks_Model> playerList = new List<GolfLinks_Model>();


		/// <summary>
		/// Datas the data recieved.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void Data_DataRecieved(object sender, SharedProject.WebService.DataRecievdEventArgs e)
			{
			Console.WriteLine("Get Links====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
			var handler = DataCallBack;
			if (e.HttpCode == HttpStatusCode.OK)
				{

				try
					{
					if (e.Data!="[]")
						{
					//	var List = JToken.Parse(e.Data).SelectToken("players").ToString();

						playerList = JsonConvert.DeserializeObject<List<GolfLinks_Model>>(e.Data);
					}
					}
				catch (Exception)
					{
					if (handler == null) return;
					handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.NoContent, Data = new List<GolfLinks_Model>() });
					}

				if (handler == null) return;
				handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = e.HttpCode, Data = playerList });
				}
			else {
				if (handler == null) return;
				handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = e.HttpCode, Data = new List<GolfLinks_Model>() });
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

			public List<GolfLinks_Model> Data
				{
				get;
				set;
				}
			}
		}
	}
