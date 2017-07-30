using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedProject.Classes;

namespace SharedProject
	{
	public class API_SearchPlayer
		{
		readonly string userId;
		readonly string criteria;
		readonly Enums.LinkStatus linkStatus;

		public API_SearchPlayer(string UserId,string Criteria,Enums.LinkStatus LinkStatus)
			{
			this.linkStatus = LinkStatus;
			this.criteria = Criteria;
			this.userId = UserId;
			}


		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataCallBack;

		public async Task<bool> Call()
			{ 

			var body = new Requests_API.SearchPalyer();

			var namevalue = new NameValueCollection();
			namevalue.Add(body.UserId, userId);
			namevalue.Add(body.Criteria, criteria);

			if (linkStatus != Enums.LinkStatus.None)
				{
				namevalue.Add(body.LinkStatus, ((int)linkStatus).ToString());
				}else
				{
				namevalue.Add(body.LinkStatus,"null");
				}


			var data = new WebService(ApiAddresses.SearchPlayer, namevalue, "GET");


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
			Console.WriteLine("SearchPlayer====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
			var handler = DataCallBack;
			if (e.HttpCode == HttpStatusCode.OK)
				{

				try
					{
					if (e.Data != "[]")
						{
						e.Data = e.Data.Replace("linkStatus", "status");
						var List = JToken.Parse(e.Data).SelectToken("").ToString();
						playerList = JsonConvert.DeserializeObject<List<GolfLinks_Model>>(List);
					}else
						{
						if (handler == null) return;
						handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.NoContent, Data = new List<GolfLinks_Model>() });
						}
					}
				catch (Exception)
					{
					if (handler == null) return;
					handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.Conflict, Data = new List<GolfLinks_Model>(),Body=e.Data });
					}

				if (handler == null) return;
				handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = e.HttpCode, Data = playerList });
				}
			else {
				if (handler == null) return;
				handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = e.HttpCode, Data = new List<GolfLinks_Model>(),Body=e.Data });
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

			public string Body
				{
				get;
				set;
				}
			}
		}
	}
