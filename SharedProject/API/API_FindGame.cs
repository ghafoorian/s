using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharedProject
	{
	public class API_FindGame
		{


		readonly NameValueCollection namevalue;

		public API_FindGame(NameValueCollection namevalue)
			{
			this.namevalue = namevalue;
			}


		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataCallBack;



		private List<GameView_Model> gameList = new List<GameView_Model>();

		public async Task<bool> Call()
			{

			var data = new WebService(ApiAddresses.FindMatch, namevalue,"GET");


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
			Console.WriteLine("findGame====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
			var handler = DataCallBack;
			if (e.HttpCode == HttpStatusCode.OK)
				{
				
				try
					{
					var matchList = JToken.Parse(e.Data).SelectToken("matchList").ToString();

					gameList = JsonConvert.DeserializeObject<List<GameView_Model>>(matchList);
					}
				catch (Exception)
					{
					if (handler == null) return;
					handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.Conflict, Data = new List<GameView_Model>(),body=e.Data });
					}

				if (handler == null) return;
				handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = e.HttpCode, Data = gameList });
				}
			else {
				if (handler == null) return;
				handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = e.HttpCode , Data=new List<GameView_Model>(),body=e.Data});
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
			public string body
				{
				get;
				set;
			}
			}


		}
	}
