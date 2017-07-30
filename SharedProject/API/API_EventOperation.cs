using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using SharedProject.Classes;

namespace SharedProject
	{
	public class API_EventOperation
		{

		readonly Classes.Enums.EventOperation _action;

		private NameValueCollection namevalue;


		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataCallBack;

		readonly string eventId;
		readonly string reserved;

		public API_EventOperation(Enums.EventOperation Action,string EventId,string Reserved)
			{
			this.reserved = Reserved;
			this.eventId = EventId;
			this._action = Action;
			}


		public async Task<bool> Call()
			{


			var body = new Requests_API.EventOperation();
			namevalue = new NameValueCollection();
			namevalue.Add(body.EventId, eventId);
			namevalue.Add(body.ActionType,((int)_action).ToString());
			namevalue.Add(body.ReservedFor,reserved);


			var data = new WebService(ApiAddresses.EventOperation, namevalue, "POST");


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
			Console.WriteLine("Event Operation====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
			var handler = DataCallBack;
			if (e.HttpCode == HttpStatusCode.OK)
				{

				try
					{


					if (handler == null) return;
					handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = e.HttpCode, Data = e.Data });

					}
				catch (Exception)
					{
					if (handler == null) return;
					handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.Conflict, Data = e.Data });
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
