using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharedProject
	{
	public class API_MatchPlayers
		{
		readonly string matchId;

		public API_MatchPlayers(string matchId)
			{
			this.matchId = matchId;
			}

		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataCallBack;

		public async Task<bool> Call()
			{

			var body = new Requests_API.MatchPlayers();

			var namevalue = new NameValueCollection();
			namevalue.Add(body.MatchId, matchId);


			var data = new WebService(ApiAddresses.MatchPlayers, namevalue, "GET");


			data.DataRecieved += Data_DataRecieved;


			await data.Connect();

			return false;


			}


		private List<Player_Model> playerList = new List<Player_Model>();


		/// <summary>
		/// Datas the data recieved.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void Data_DataRecieved(object sender, SharedProject.WebService.DataRecievdEventArgs e)
			{
			Console.WriteLine("MatchPlayers====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
			var handler = DataCallBack;
			if (e.HttpCode == HttpStatusCode.OK)
				{

				try
					{
					var List = JToken.Parse(e.Data).SelectToken("players").ToString();
					playerList = JsonConvert.DeserializeObject<List<Player_Model>>(List);
					}
				catch (Exception)
					{
					if (handler == null) return;
					handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.Conflict, Data = new List<Player_Model>() });
					}

				if (handler == null) return;
				handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = e.HttpCode, Data = playerList });
				}
			else {
				if (handler == null) return;
				handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = e.HttpCode, Data = new List<Player_Model>() });
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

			public List<Player_Model> Data
				{
				get;
				set;
				}
			}
		}
	}
