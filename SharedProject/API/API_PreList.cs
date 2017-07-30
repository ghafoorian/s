

using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SharedProject
{
    public class API_PreList
    {

        /// <summary>
        /// event Handler
        /// </summary>
        public event EventHandler<DataRecievdEventArgs> DataCallBack;

        public API_PreList()
        {
        }

        private string clubImg = string.Empty;


        public async Task<bool> Call()
        {

            var data = new WebService(ApiAddresses.PreList);


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

            var handler = DataCallBack;
            if (e.HttpCode == HttpStatusCode.OK && e.Data != "[]")
            {
                Console.WriteLine("PRE List => " + e.Data);
                //Add data to Database for caching


                UserHolder.PreList = e.Data;

                var meetingPlaces = JsonConvert.DeserializeObject<List<PreList_Model.meetingPlaces>>(JToken.Parse(e.Data).SelectToken("meetingPlaces").ToString());

                var scoringTypes = JsonConvert.DeserializeObject<List<PreList_Model.scoringTypes>>(JToken.Parse(e.Data).SelectToken("scoringTypes").ToString());

                var sections = JToken.Parse(e.Data).SelectToken("sections").ToString();
                var sectionsList = JsonConvert.DeserializeObject<List<PreList_Model.sections>>(sections);


                var clubDirectories = JToken.Parse(e.Data).SelectToken("clubDirectories").ToString();
                var clubDirectoriesList = JsonConvert.DeserializeObject<List<PreList_Model.clubDirectories>>(clubDirectories);


                var courses = JToken.Parse(e.Data).SelectToken("courses").ToString();
                var coursesList = JsonConvert.DeserializeObject<List<PreList_Model.courses>>(courses);

                var interests = JToken.Parse(e.Data).SelectToken("interests").ToString();
                var interestsList = JsonConvert.DeserializeObject<List<PreList_Model.interests>>(interests);

                try
                {

                    clubImg = JToken.Parse(e.Data).SelectToken("clubInfo.logo").ToString();
                    UserHolder.UserId = JToken.Parse(e.Data).SelectToken("userInfo.userId").ToString();

                    UserHolder.MainCourseName = (string.IsNullOrEmpty(UserHolder.MainCourseName)) ? coursesList[0].name : UserHolder.MainCourseName;
                    UserHolder.MainCourseId = (string.IsNullOrEmpty(UserHolder.MainCourseId)) ? coursesList[0].id : UserHolder.MainCourseId;

                    UserHolder.GolfClubName = JToken.Parse(e.Data).SelectToken("clubInfo.clubName").ToString();
                    UserHolder.GolfClubId = JToken.Parse(e.Data).SelectToken("clubInfo.clubDirectoryId").ToString();
                }
                catch (Exception)
                {
                    Console.WriteLine("golfClub Exception");
                }

                /// <summary>
                /// If the default course name and id didn't set before.
                /// </summary>
                if (string.IsNullOrEmpty(UserHolder.MainCourseId))
                {
                    UserHolder.MainCourseId = coursesList[0].id;
                    UserHolder.MainCourseName = coursesList[0].name;
                }

                if (handler == null) return;
                handler.Invoke(this, new DataRecievdEventArgs()
                {
                    Status = true,
                    HttpCode = e.HttpCode,
                    MeetingPlaces_List = meetingPlaces,
                    //MatchFormats_List = new List<PreList_Model.MatchFormats>(),
                    ScoringTypes = scoringTypes,
                    Sections_List = sectionsList,
                    Courses_List = coursesList,
                    Interests_List = interestsList,
                    ClubDirectories_List = clubDirectoriesList,
                    ClubImg = clubImg
                });
            }
            else
            {
                UserHolder.PreList = string.Empty;
                handler?.Invoke(this, new DataRecievdEventArgs()
                {
                    Status = false,
                    HttpCode = e.HttpCode,
                    //MatchFormats_List = new List<PreList_Model.MatchFormats>(),
                    ScoringTypes = new List<PreList_Model.scoringTypes>(),
                    MeetingPlaces_List = new List<PreList_Model.meetingPlaces>(),
                    Sections_List = new List<PreList_Model.sections>(),
                    Courses_List = new List<PreList_Model.courses>(),
                    Interests_List = new List<PreList_Model.interests>(),
                    ClubDirectories_List = new List<PreList_Model.clubDirectories>(),
                    ClubImg = clubImg
                });
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

            public List<PreList_Model.meetingPlaces> MeetingPlaces_List
            {
                get;
                set;
            }

            //public List<PreList_Model.MatchFormats> MatchFormats_List
            //	{
            //	get;
            //	set;
            //	}

            public List<PreList_Model.scoringTypes> ScoringTypes
            {
                get;
                set;
            }

            public List<PreList_Model.sections> Sections_List
            {
                get;
                set;
            }

            public List<PreList_Model.courses> Courses_List
            {
                get;
                set;
            }

            public List<PreList_Model.interests> Interests_List
            {
                get;
                set;
            }

            public List<PreList_Model.clubDirectories> ClubDirectories_List
            {
                get;
                set;
            }

            public string ClubImg
            {
                get;
                set;
            }

        }

    }
}

