using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace SharedProject
{
    public class API_GetProfile
    {

        /// <summary>
        /// event Handler
        /// </summary>
        public event EventHandler<DataRecievdEventArgs> DataCallBack;

        public API_GetProfile()
        {
        }

        readonly string userId;

        public API_GetProfile(string UserId)
        {
            this.userId = UserId;
        }

        public async Task<bool> Call()
        {


            var body = new Requests_API.Profile();

            var namevalue = new NameValueCollection();
            namevalue.Add(body.userid, userId);

            var data = (string.IsNullOrEmpty(userId)) ? new WebService(ApiAddresses.GetProfile) :
                new WebService(ApiAddresses.GetUserProfile, namevalue, "GET");

            data.DataRecieved += Data_DataRecieved;

            await data.Connect();

            return false;


        }


        //Prop

        private string _FirstName { get; set; }
        private string _LastName { get; set; }
        private string _Age { get; set; }
        private string _Gender { get; set; }
        private string _Postcode { get; set; }
        private string _IsSmoker { get; set; }
        private string _HandiCap { get; set; }
        private string _MemberType { get; set; }
        private string _Occupation { get; set; }
        private string _PrefferedSection { get; set; }
        private string _Biography { get; set; }
        private List<string> _InterestIds { get; set; }
        private string _PrefferedHandicapFrom { get; set; }
        private string _PrefferedHandicapTo { get; set; }
        private string _MondayTimeFrom { get; set; }
        private string _MondayTimeTo { get; set; }
        private string _SundayTimeFrom { get; set; }
        private string _SundayTimeTo { get; set; }
        private string _TuesdayTimeFrom { get; set; }
        private string _TuesdayTimeTo { get; set; }
        private string _WednesdayTimeFrom { get; set; }
        private string _WednesdayTimeTo { get; set; }
        private string _ThursdayTimeFrom { get; set; }
        private string _ThursdayTimeTo { get; set; }
        private string _FridayTimeFrom { get; set; }
        private string _FridayTimeTo { get; set; }
        private string _SaturdayTimeFrom { get; set; }
        private string _SaturdayTimeTo { get; set; }
        private string _Mobile { get; set; }
        private string _Email { get; set; }
        private string _UserName { get; set; }
        private string _Id { get; set; }
        private string _avatar { get; set; }




        /// <summary>
        /// Datas the Profile data recieved.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>


        void Data_DataRecieved(object sender, SharedProject.WebService.DataRecievdEventArgs e)
        {

            Console.WriteLine("Profile ===>  " + e.Status + " " + e.HttpCode + " " + e.Data);
            var handler = DataCallBack;
            if (e.HttpCode == HttpStatusCode.OK)
            {

                try
                {
                    var data = e.Data;

                    //	_Age = JToken.Parse(data).SelectToken("age").ToString();
                    _Age = string.Empty;
                    _Gender = JToken.Parse(data).SelectToken("gender").ToString();
                    _Postcode = JToken.Parse(data).SelectToken("postcode").ToString();
                    _IsSmoker = JToken.Parse(data).SelectToken("isSmoker").ToString();
                    _HandiCap = JToken.Parse(data).SelectToken("handicap").ToString().Replace("-", "+");
                    _MemberType = JToken.Parse(data).SelectToken("memberType").ToString();
                    _Occupation = JToken.Parse(data).SelectToken("occupation").ToString();
                    _PrefferedSection = JToken.Parse(data).SelectToken("prefferedSection").ToString();
                    _Biography = JToken.Parse(data).SelectToken("biography").ToString();
                    _PrefferedHandicapFrom = JToken.Parse(data).SelectToken("prefferedHandicapFrom").ToString();
                    _PrefferedHandicapTo = JToken.Parse(data).SelectToken("prefferedHandicapTo").ToString();
                    _MondayTimeFrom = JToken.Parse(data).SelectToken("mondayTimeFrom").ToString();
                    _MondayTimeTo = JToken.Parse(data).SelectToken("mondayTimeTo").ToString();
                    _SundayTimeFrom = JToken.Parse(data).SelectToken("sundayTimeFrom").ToString();
                    _SundayTimeTo = JToken.Parse(data).SelectToken("sundayTimeTo").ToString();
                    _TuesdayTimeFrom = JToken.Parse(data).SelectToken("tuesdayTimeFrom").ToString();
                    _TuesdayTimeTo = JToken.Parse(data).SelectToken("tuesdayTimeTo").ToString();
                    _WednesdayTimeFrom = JToken.Parse(data).SelectToken("wednesdayTimeFrom").ToString();
                    _WednesdayTimeTo = JToken.Parse(data).SelectToken("wednesdayTimeTo").ToString();
                    _ThursdayTimeFrom = JToken.Parse(data).SelectToken("thursdayTimeFrom").ToString();
                    _ThursdayTimeTo = JToken.Parse(data).SelectToken("thursdayTimeTo").ToString();
                    _FridayTimeFrom = JToken.Parse(data).SelectToken("fridayTimeFrom").ToString();
                    _FridayTimeTo = JToken.Parse(data).SelectToken("fridayTimeTo").ToString();
                    _SaturdayTimeFrom = JToken.Parse(data).SelectToken("saturdayTimeFrom").ToString();
                    _SaturdayTimeTo = JToken.Parse(data).SelectToken("saturdayTimeTo").ToString();
                    _Mobile = JToken.Parse(data).SelectToken("mobile").ToString();
                    _Email = JToken.Parse(data).SelectToken("email").ToString();
                    _UserName = JToken.Parse(data).SelectToken("userName").ToString();
                    //_Id = JToken.Parse(data).SelectToken("id").ToString();
                    _FirstName = JToken.Parse(data).SelectToken("firstName").ToString();
                    _LastName = JToken.Parse(data).SelectToken("lastName").ToString();
                    _avatar = JToken.Parse(data).SelectToken("avatar").ToString();


                    var interests = JToken.Parse(data).SelectToken("interestIds").ToString();
                    _InterestIds = JsonConvert.DeserializeObject<List<string>>(interests);

                    if (string.IsNullOrEmpty(userId))
                    {
                        UserHolder.Age = _Age;
                        UserHolder.PostalCode = _Postcode;
                        UserHolder.IsSmoker = _IsSmoker;
                        UserHolder.Handicap = _HandiCap;
                        UserHolder.MemberTypeId = _MemberType;
                        UserHolder.BioGraphy = _Biography;
                        UserHolder.HandicapTo = _PrefferedHandicapTo;
                        UserHolder.HandicapFrom = _PrefferedHandicapFrom;
                        UserHolder.Email = _Email;
                        UserHolder.Mobile = _Mobile;
                        UserHolder.UserName = _UserName;
                        //UserHolder.UserId = _Id;
                        UserHolder.prefferedSection = _PrefferedSection;
                        UserHolder.Occupation = _Occupation;
                        UserHolder.Gender = _Gender;
                        UserHolder.FirstName = _FirstName;
                        UserHolder.LastName = _LastName;
                    }

                    if (handler == null) return;
                    handler.Invoke(this, new DataRecievdEventArgs()
                    {
                        Status = true,
                        HttpCode = e.HttpCode,

                        Age = _Age,
                        Gender = _Gender,
                        Postcode = _Postcode,
                        IsSmoker = _IsSmoker,
                        HandiCap = _HandiCap,
                        MemberType = _MemberType,
                        Occupation = _Occupation,
                        PrefferedSection = _PrefferedSection,
                        Biography = _Biography,
                        InterestIds = _InterestIds,
                        PrefferedHandicapFrom = _PrefferedHandicapFrom,
                        PrefferedHandicapTo = _PrefferedHandicapTo,
                        MondayTimeFrom = _MondayTimeFrom,
                        MondayTimeTo = _MondayTimeTo,
                        SundayTimeFrom = _SundayTimeFrom,
                        SundayTimeTo = _SundayTimeTo,
                        TuesdayTimeFrom = _TuesdayTimeFrom,
                        TuesdayTimeTo = _TuesdayTimeTo,
                        WednesdayTimeFrom = _WednesdayTimeFrom,
                        WednesdayTimeTo = _WednesdayTimeTo,
                        ThursdayTimeFrom = _ThursdayTimeFrom,
                        ThursdayTimeTo = _ThursdayTimeTo,
                        FridayTimeFrom = _FridayTimeFrom,
                        FridayTimeTo = _FridayTimeTo,
                        SaturdayTimeFrom = _SaturdayTimeFrom,
                        SaturdayTimeTo = _SaturdayTimeTo,
                        Mobile = _Mobile,
                        Email = _Email,
                        UserName = _UserName,
                        Id = _Id,
                        FirstName = _FirstName,
                        LastName = _LastName,
                        Avatar = _avatar

                    });
                }
                catch
                {
                    Console.WriteLine("profile error");
                }
            }
            else
            {
                if (handler == null) return;
                handler.Invoke(this, new DataRecievdEventArgs() { Status = false, HttpCode = e.HttpCode });
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


            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Age { get; set; }
            public string Gender { get; set; }
            public string Postcode { get; set; }
            public string IsSmoker { get; set; }
            public string HandiCap { get; set; }
            public string MemberType { get; set; }
            public string Occupation { get; set; }
            public string PrefferedSection { get; set; }
            public string Biography { get; set; }
            public List<string> InterestIds { get; set; }
            public string PrefferedHandicapFrom { get; set; }
            public string PrefferedHandicapTo { get; set; }
            public string MondayTimeFrom { get; set; }
            public string MondayTimeTo { get; set; }
            public string SundayTimeFrom { get; set; }
            public string SundayTimeTo { get; set; }
            public string TuesdayTimeFrom { get; set; }
            public string TuesdayTimeTo { get; set; }
            public string WednesdayTimeFrom { get; set; }
            public string WednesdayTimeTo { get; set; }
            public string ThursdayTimeFrom { get; set; }
            public string ThursdayTimeTo { get; set; }
            public string FridayTimeFrom { get; set; }
            public string FridayTimeTo { get; set; }
            public string SaturdayTimeFrom { get; set; }
            public string SaturdayTimeTo { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Id { get; set; }
            public string Avatar { get; set; }

        }


    }
}
