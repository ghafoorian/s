using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;


namespace SharedProject
	{
	public class API_GolfLinkOperation
		{

		readonly Classes.Enums.GolfLinkAction _action;


		readonly NameValueCollection namevalue;

		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataCallBack;


		public API_GolfLinkOperation(Classes.Enums.GolfLinkAction action, string userId)

			{
			var body= new Requests_API.GolfLinkAction();
			namevalue = new NameValueCollection();
			namevalue.Add(body.IntendedUserId, userId);

			_action = action;
			}

		public async Task<bool> Call()
			{

			WebService data;

			switch (_action)
				{
				case Classes.Enums.GolfLinkAction.AcceptLink:

					data = new WebService(ApiAddresses.AcceptLink, namevalue, "POST");

					break;

				case Classes.Enums.GolfLinkAction.IgnoreLink:
					data = new WebService(ApiAddresses.IgnoreLink, namevalue, "POST");

					break;

				case Classes.Enums.GolfLinkAction.RemoveLink:
					data = new WebService(ApiAddresses.RemoveLink, namevalue, "POST");

					break;

				case Classes.Enums.GolfLinkAction.RequestlLink:
					data = new WebService(ApiAddresses.RequestLink, namevalue, "POST");

					break;

				default:
					data = new WebService(ApiAddresses.AcceptLink, namevalue, "POST");
					break;
			}

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
			Console.WriteLine("GolfLinkAction ====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
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
