using System;
namespace SharedProject
	{
	public static class  DigitsOnly
		{

		public static bool IsDigitsOnly(string str)
			{
			foreach (char c in str)
				{
				if (c < '0' || c > '9')
					return false;
				}

			return true;
			}
		}
	}
