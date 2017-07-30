using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SharedProject
	{
	public class PreListCache
		{

		public async Task<bool> GetCachingData()
			{
			Console.WriteLine("PreList");

			var prelist = new API_PreList();

			prelist.DataCallBack += (sender2, e2) =>
			{


			};
			await prelist.Call();

			return true;

			}

		/// <summary>
		/// Retrives the sections.
		/// </summary>
		/// <returns>The sections.</returns>
		public List<PreList_Model.sections> RetriveSections()
			{
			if (!string.IsNullOrEmpty(UserHolder.PreList))
				{
				var sections = JToken.Parse(UserHolder.PreList).SelectToken("sections").ToString();
				return JsonConvert.DeserializeObject<List<PreList_Model.sections>>(sections);
				}
			else
				{
				return new List<PreList_Model.sections>();
				}
			}


		/// <summary>
		/// Retrives the locations.
		/// </summary>
		/// <returns>The locations.</returns>
		public List<PreList_Model.clubDirectories> RetriveclubDirectories()
			{

			if (!string.IsNullOrEmpty(UserHolder.PreList))
				{
				var locations = JToken.Parse(UserHolder.PreList).SelectToken("clubDirectories").ToString();
				return JsonConvert.DeserializeObject<List<PreList_Model.clubDirectories>>(locations);

				}
			else
				{
				return new List<PreList_Model.clubDirectories>();
				}
			}


		/// <summary>
		/// Retrives the courses.
		/// </summary>
		/// <returns>The courses.</returns>
		public List<PreList_Model.courses> RetriveCourses()
			{

			if (!string.IsNullOrEmpty(UserHolder.PreList))
				{
				var courses = JToken.Parse(UserHolder.PreList).SelectToken("courses").ToString();
				return JsonConvert.DeserializeObject<List<PreList_Model.courses>>(courses);

				}
			else
				{
				return new List<PreList_Model.courses>();
				}


			}



		/// <summary>
		/// Retrives the scoring types.
		/// </summary>
		/// <returns>The scoring types.</returns>
		public List<PreList_Model.scoringTypes> RetriveScoringTypes()
			{
			if (!string.IsNullOrEmpty(UserHolder.PreList))
				{
				var scoringType = JToken.Parse(UserHolder.PreList).SelectToken("scoringTypes").ToString();
				return JsonConvert.DeserializeObject<List<PreList_Model.scoringTypes>>(scoringType);
				}
			else
				{
				return new List<PreList_Model.scoringTypes>();
				}

			}


		/// <summary>
		/// Retrives the interests.
		/// </summary>
		/// <returns>The interests.</returns>
		public List<PreList_Model.interests> RetriveInterests()
			{

			if (!string.IsNullOrEmpty(UserHolder.PreList))
				{
				var inerests = JToken.Parse(UserHolder.PreList).SelectToken("interests").ToString();
				return JsonConvert.DeserializeObject<List<PreList_Model.interests>>(inerests);

				}
			else
				{
				return new List<PreList_Model.interests>();
				}


			}


		/// <summary>
		/// Retrives the play now locations.
		/// </summary>
		/// <returns>The play now locations.</returns>
		public List<PreList_Model.playNowLocations> RetrivePlayNowLocations()
			{

			if (!string.IsNullOrEmpty(UserHolder.PreList))
				{
				var inerests = JToken.Parse(UserHolder.PreList).SelectToken("playNowLocations").ToString();
				return JsonConvert.DeserializeObject<List<PreList_Model.playNowLocations>>(inerests);

				}
			else
				{
				return new List<PreList_Model.playNowLocations>();
				}


			}

		public List<PreList_Model.meetingPlaces> RetrivemeetingPlaces()
			{

			if (!string.IsNullOrEmpty(UserHolder.PreList))
				{
				var meeting = JToken.Parse(UserHolder.PreList).SelectToken("meetingPlaces").ToString();
				return JsonConvert.DeserializeObject<List<PreList_Model.meetingPlaces>>(meeting);

				}
			else
				{
				return new List<PreList_Model.meetingPlaces>();
				}


			}

		/// <summary>
		/// Retrives the name of the golf club.
		/// </summary>
		/// <returns>The golf club name.</returns>
		/// <param name="Id">Identifier.</param>
		public string RetriveGolfClubName(string Id)
			{

			var golfClubList = RetriveclubDirectories();

			foreach (var item in golfClubList)
				{
				if (item.id == Id)
					return item.name;
				}
			return string.Empty;
			}


		/// <summary>
		/// Retrives the name of the meeting place.
		/// </summary>
		/// <returns>The meeting place name.</returns>
		/// <param name="Id">Identifier.</param>
		public string RetriveMeetingPlaceName(string Id)
			{

			var meetingList = RetrivemeetingPlaces();

			foreach (var item in meetingList)
				{
				if (item.id == Id)
					return item.name;
				}
			return string.Empty;
			}

		}
	}