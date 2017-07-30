using System;
namespace SharedProject
	{
	public class Player_Model
		{

		//public string userId { 
		//	get{
		//		if (userId == null)
		//			{
		//			userId = string.Empty;
		//			}
		//		return userId;
		//	}
		//	set{value=userId;}
		//}

		private string _avatar = string.Empty;

		private string _handicap = "0";

		public string userId { get; set;}



		public string avatar {
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

		public string handiCap { get
			{
				return _handicap;

			}
			set{
				_handicap = value.Replace("-", "+");	
			}
		}

		public string linkStatus { get; set;}

		public string fullName { get; set;}

		}

	}