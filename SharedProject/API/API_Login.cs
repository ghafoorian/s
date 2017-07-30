using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;



namespace SharedProject
	{
	public class API_Login
		{
		readonly string _username;
		readonly string _password;


		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataCallBack;


		public API_Login(string username, string password)

			{
			this._password = password;
			this._username = username;
			}

		    
		    //public TaskCompletionSource<bool> call = new TaskCompletionSource<bool>();
		 
			public async Task<bool> Call()
			{



			var body = new Requests_API.Login();

			var namevalue = new NameValueCollection();
			namevalue.Add(body.Username, _username);
			namevalue.Add(body.Password, _password);

			var data = new WebService(ApiAddresses.Login, namevalue,"POST");


			data.DataRecieved+= Data_DataRecieved;


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
			Console.WriteLine("LOGIN====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
			var handler = DataCallBack;
			if (e.HttpCode == HttpStatusCode.OK)
				{
		
				var acc = JToken.Parse(e.Data).SelectToken("access_token").ToString();
				Console.WriteLine("login acc ==> " + acc);
				UserHolder.AccessToken = "Bearer " +acc;
				if (handler == null) return;
				handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = e.HttpCode, Data = e.Data });
				}
			else {
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
