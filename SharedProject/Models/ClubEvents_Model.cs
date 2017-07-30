using System;
namespace SharedProject
{
    public class ClubEvents_Model
    {

        private string _avatar = string.Empty;

        public string id { get; set; }
        public string date { get; set; }
        public string name { get; set; }
        public string meetingPlaceId { get; set; }
        public string meetingPlaceTitle { get; set; }
        public string cost { get; set; }
        public string instructions { get; set; }
        public string maxSlots { get; set; }
        public string isAttended { get; set; }
        public string spacesAvailable { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string maxReserve { get; set; }
        public string avatar
        {
            get
            {
                return avatar = _avatar;
            }
            set
            {
                _avatar = (!string.IsNullOrEmpty(value)) ? value.Replace("/uploads/", "uploads/") : _avatar;
            }
        }
        public string reservedFor { get; set; }
        public string eventType { get; set; }
        public string addToMyDiary { get; set; }
        public string status { get; set; }
    }
}
