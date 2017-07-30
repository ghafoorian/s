using System.Collections.Generic;

namespace SharedProject
	{
	public class PreList_Model
		{

		/// <summary>
		/// meetingPlaces.
		/// </summary>
		public class meetingPlaces
			{

			public string id
				{
				get;
				set;
				}

			public string name
				{
				get;
				set;
				}

			public string meetingPlaceType
				{
				get;
				set;
				}

			}

		public class clubDirectories
			{

			public string id
				{
				get;
				set;
				}

			public string name
				{
				get;
				set;
				}
			}


		/// <summary>
		/// Play now locations.
		/// </summary>
		public class playNowLocations
			{

			public string id
				{
				get;
				set;
				}

			public string name
				{
				get;
				set;
				}
			}


		/// <summary>
		/// Sections.
		/// </summary>
		public class sections
			{

			public string id { get; set; }
			public string name { get; set; }
			public List<teeColours> teeColours;

			}

		/// <summary>
		/// Tee colours.
		/// </summary>
		public class teeColours
			{

			public string id { get; set; }
			public string name { get; set; }

			}

		/// <summary>
		/// Courses.
		/// </summary>
		public class courses
			{
			public string id { get; set; }
			public string name { get; set; }

			}

		public class interests
			{
			public string id { get; set; }
			public string title { get; set; }
			public List<subs> subs { get; set; }
			}

		public class subs
			{
			public string id { get; set; }
			public string title { get; set; }
			}


		/// <summary>
		/// Scoring types.
		/// </summary>
		public class scoringTypes
			{
			public string id { get; set; }
			public string name { get; set; }
			}


		/// <summary>
		/// Match formats.
		/// </summary>
		public class MatchFormats
			{

			public string id
				{
				get;
				set;
				}

			public string name
				{
				get;
				set;
				}

			}

		}
	}
