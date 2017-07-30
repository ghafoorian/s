using System;
using System.Collections.Generic;

namespace SharedProject
{

    /// <summary>
    /// Game view model.
    /// </summary>



    public class GameView_Model
    {

        private string _logo = string.Empty;



        public string id { get; set; }

        public string name { get; set; }

        public string date { get; set; }

        public string startTime { get; set; }

        public string memberType { get; set; }

        public string holesCount { get; set; }

        public string matchNumber { get; set; }

        public string matchStatus { get; set; }

        public string description { get; set; }

        public string matchFormatId { get; set; }

        public string courseId { get; set; }

        public List<PreList_Model.sections> sections { get; set; }

        public string matchFormatName { get; set; }

        public string courseName { get; set; }

        public string spacesAvailable { get; set; }

        public string lastTeeTime { get; set; }

        public string cost { get; set; }

        public string minHandicap { get; set; }

        public string maxHandicap { get; set; }

        public string logo
        {
            get
            {
                return logo = _logo;
            }
            set
            {
                _logo = (!string.IsNullOrEmpty(value)) ? value.Replace("/uploads/", "uploads/") : _logo;
            }

        }

        public string location { get; set; }

        public string isAttended { get; set; }

        public string isOwner { get; set; }

        public string scoringTypeName { get; set; }

        public string scoringTypeId { get; set; }

        public string locationId { get; set; }

        public string meetingPlaceId { get; set; }

        public string cancelReason { get; set; }

    }


}
