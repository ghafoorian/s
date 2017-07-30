using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SharedProject.Classes;


namespace SharedProject
	{
	public class WebService
		{

		private readonly string _address;
		private readonly NameValueCollection _data;
		private readonly int _attemptTimes;
		private int _attempt;
		readonly string _method;

		//Event NoInternet close
		public static event EventHandler NoInternetEvent = delegate { };

		/// <summary>
		/// event Handler
		/// </summary>
		public event EventHandler<DataRecievdEventArgs> DataRecieved;
		public static event EventHandler UnauthorizedEvent = delegate { };


		public WebService()
			{

			}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:SharedProject.WebService"/> class.
		/// </summary>
		/// <param name="address">Address.</param>
		/// <param name="data">Data.</param>
		/// <param name="attempt">Attempt.</param>
		public WebService(string address, NameValueCollection data, int attempt, string method)

			{
			_method = method;
			_address = address;
			_attemptTimes = attempt;
			_data = (data);
			}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:SharedProject.WebService"/> class.
		/// </summary>
		/// <param name="address">Address.</param>
		/// <param name="data">Data.</param>
		public WebService(string address, NameValueCollection data, string method)

			{

			_address = address;
			_attemptTimes = 2;
			_data = (data);
			_method = method;

			}

		public WebService(string address)

			{

			_address = address;
			_attemptTimes = 2;
			_data = new NameValueCollection();
			_method = "GET";

			}

		/// <summary>
		/// if PingResult = "ok" it would call RetriveData()
		/// </summary>
		/// <returns>PingReport.Repor</returns>
		public async Task<PingServer.PingResult> Connect()
			{
			var pingtest = new PingServer(AppGlobal.Server.Address);
			Console.WriteLine($"URL -> {AppGlobal.Server.Address + _address}");

			var pingresult = await pingtest.Test();
			Console.WriteLine($"Ping Result -> {PingReport.Report(pingresult)}");


			if (pingresult != PingServer.PingResult.Ok)
				{

				var handler = DataRecieved;

				NoInternetEvent.Invoke(this, EventArgs.Empty);

				if (handler != null)
					{
					handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = HttpStatusCode.RequestTimeout, Data = string.Empty });
					}

				return pingresult;
				}
			else
				{
				Retrivedata();
				}






			return (pingresult);

			}



		/// <summary>
		/// using ExtendedWebClient class to post data
		/// </summary>
		public void Retrivedata()
			{





			// ignoring the validation server Error

			//ServicePointManager
			//    .ServerCertificateValidationCallback +=
			//    (Sender, cert, chain, sslPolicyErrors) => true;


			//var client = new RestClient("http://goftagram.com/sarkoobi/status-code/post/sample/400");
			//var client = new RestClient("http://api.sanjup.com/noResponse");

			var client = new RestClient(AppGlobal.Server.Address + _address);

			var request = new RestRequest();


			//client.AddDefaultHeader("Accept", "application/json");
			//client.AddDefaultHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJMZXZlbDZVc2VyIiwianRpIjoiMTgzYjgyZmItMGUwZi00NTM0LWE2MzAtOTQ2ZGUyNTM5NWFmIiwiaWF0IjoxNDgzODcxMzY0LCJDbGFpbSI6IlZhbHVlIiwicm9sZSI6IkxldmVsNiIsIm5iZiI6MTQ4Mzg3MTM2MywiZXhwIjoxNDgzOTAwMTYzLCJpc3MiOiJTdXBlckF3ZXNvbWVUb2tlblNlcnZlciIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTc4My8ifQ.WlS_Ax4KoXfjWQNN6hnJJf6ZHC8oJSzVEPNbWY7QMWA");

			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Authorization", UserHolder.AccessToken);
			// request.AddCookie(".AspNetCore.Identity.Application", UserHolder.GolfClubId);


			string sendString = "";
			switch (_method)
				{
				case "POST":
					request.Method = Method.POST;

					foreach (var item in _data.AllKeys)
						{
						request.AddParameter(item, _data[item]);
						sendString += $" {item} : {_data[item]}  \r";
						Console.WriteLine(item + ": " + _data[item]);
						}
					Console.WriteLine("sendString = > " + sendString);
					break;

				case "GET":
					request.Method = Method.GET;

					foreach (var item in _data.AllKeys)
						{
						request.AddQueryParameter(item, _data[item]);

						Console.WriteLine(item + ": " + _data[item]);
						}

					break;
				default:
					request.Method = Method.POST;
					break;
				}



			// execute the request
			/// <summary>
			/// Occurs when data recieved.
			/// </summary>
			client.ExecuteAsync(request, response =>
			{
				Console.WriteLine("ResponseUri=> " + response.ResponseUri);

				//Console.WriteLine(response.ErrorMessage + " code =>" + response.StatusCode);
				//Console.WriteLine("ErrorException=> " + response.ErrorException);
				//Console.WriteLine("Headers=> " + response.Headers);
				//Console.WriteLine("Server=> " + response.Server);
				//Console.WriteLine("StatusDescription=> " + response.StatusDescription);
				//Console.WriteLine("ContentType=> " + response.ContentType);
				////Console.WriteLine("Content=> " + response.Content);

				var handler = DataRecieved;
				try
					{
					//OK
					var result = (response.Content);
					switch (response.StatusCode)
						{
						//200
						case HttpStatusCode.OK:
							if (handler == null) return;
							handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = response.StatusCode, Data = result });
							_attempt = 0;
							break;

						//202
						case HttpStatusCode.Accepted:
							if (handler == null) return;
							handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = response.StatusCode, Data = result });
							break;

						//201
						case HttpStatusCode.Created:
							if (handler == null) return;
							handler.Invoke(this, new DataRecievdEventArgs() { Status = true, HttpCode = response.StatusCode, Data = result });
							break;

						//204
						case HttpStatusCode.NoContent:
							if (handler == null) return;
							handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = response.StatusCode, Data = result });
							break;

						//400
						case HttpStatusCode.BadRequest:
							if (handler == null) return;
							handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = response.StatusCode, Data = result });
							break;

						//401
						case HttpStatusCode.Unauthorized:
							if (handler == null) return;
							Console.WriteLine(result);
							//handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = response.StatusCode, Data = result });
							UnauthorizedEvent?.Invoke(this, EventArgs.Empty);
							break;

						//403
						case HttpStatusCode.Forbidden:
							if (handler == null) return;
							handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = response.StatusCode, Data = result });
							break;

						//405
						case HttpStatusCode.MethodNotAllowed:
							if (handler == null) return;
							handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = response.StatusCode, Data = result });
							break;


						//500
						case HttpStatusCode.InternalServerError:
							if (_attempt < _attemptTimes)
								{
								Attempt();
								}
							else
								{
								if (handler == null) return;
								handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = response.StatusCode, Data = result });
								}
							break;

						//503
						case HttpStatusCode.ServiceUnavailable:
							if (_attempt < _attemptTimes)
								{
								Attempt();
								}
							else
								{
								if (handler == null) return;
								handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = response.StatusCode, Data = result });
								}
							break;

						default:
							if (_attempt < _attemptTimes)
								{
								Attempt();
								}
							else
								{
								if (handler == null) return;
								handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = response.StatusCode, Data = result });
								}
							break;
						}

					}

				catch (WebException e) when (e.Status == WebExceptionStatus.Timeout)
					{
					// If we got here, it was a timeout exception.
					Console.WriteLine("timeOut");
					}

				catch (Exception ex)
					{

					Console.WriteLine("ex -> " + ex.ToString());

					if (_attempt < _attemptTimes)
						{
						Attempt();
						}

					}

			});

			}





		/// <summary>
		/// just attempting to retrive data if result is invalid
		/// </summary>
		private void Attempt()
			{
			_attempt += 1;
			Retrivedata();

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