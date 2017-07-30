using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;

namespace SharedProject
	{
	public class API_MatchOperation
		{

		readonly NameValueCollection namevalue;

		public API_MatchOperation(NameValueCollection namevalue)
			{
			this.namevalue = namevalue;
			}

		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataCallBack;

		public async Task<bool> Call()
			{

			var data = new WebService(ApiAddresses.MatchOperation, namevalue, "POST");


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
			Console.WriteLine("MatchOperation====>  " + e.Status + " " + e.HttpCode + " " + e.Data);
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
