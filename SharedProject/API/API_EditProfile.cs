using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace SharedProject
	{
	public class API_EditProfile
		{

		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataCallBack;

		readonly string userId;
		NameValueCollection namevalue;

		public API_EditProfile(NameValueCollection NameValue)
			{
			namevalue = NameValue;
			}



		public API_EditProfile(NameValueCollection NameValue, string UserId)
			{
			this.userId = UserId;
			namevalue = NameValue;
			}



		public async Task<bool> Call()
			{


			var body = new Requests_API.EditProfile();

			if(!string.IsNullOrEmpty(userId))
			namevalue.Add(body.UserId, userId);

			var data = (string.IsNullOrEmpty(userId)) ? new WebService(ApiAddresses.EditProfile,namevalue,"POST") :
				new WebService(ApiAddresses.EditUserProfile, namevalue, "POST");

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
			Console.WriteLine("Edit Profile ===>  " + e.Status + " " + e.HttpCode + " " + e.Data);
			var handler = DataCallBack;
			if (e.HttpCode == HttpStatusCode.OK)
				{

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
