using System;
namespace SharedProject
	{
	public class GolfLinks_Model
		{

		private string _avatar = string.Empty;

		private string _handicap = "0";



		public string userId { get; set; }
		public string avatar
			{
			get
				{
				return _avatar;
				}
			set
				{
				_avatar = value ?? string.Empty;
				}
			}

		public string firstName { get; set; }
		public string lastName { get; set; }
		public string handiCap
			{
			get
				{
				return _handicap;

				}
			set
				{
				_handicap = value?.Replace("-", "+");
				}
			}

		public string status { get; set; }
		public string fromMe { get; set; }

		}
	}

//"userId":"1dde101d-35dd-428b-aa44-d016b58123b2",
//"avatar":null,
//"firstName":"David",
//"lastName":"Syrett",
//"handicap":null,
//"linkStatus":null,
//"fromMe":false