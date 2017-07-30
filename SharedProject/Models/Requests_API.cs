using System;

namespace SharedProject
{
    public class Requests_API
    {


        /// <summary>
        /// Login.
        /// </summary>
        public class Login
        {

            public string Username => "Username";

            public string Password => "Password";


        }

        /// <summary>
        /// Golf link action User Id.
        /// </summary>
        public class GolfLinkAction
        {
            public string IntendedUserId => "IntendedUserId";
        }

        /// <summary>
        /// Match players.
        /// </summary>
        public class MatchPlayers
        {
            public string MatchId => "matchid";
        }


        /// <summary>
        /// Match view.
        /// </summary>
        public class MatchView
        {
            public string MatchId => "matchid";
            public string MatchNumber => "matchNumber";

        }

        /// <summary>
        /// Find game.
        /// </summary>
        public class FindGame
        {
            public string MatchNumber => "MatchNumber";
            public string MatchName => "Name";
            public string HolesCount => "HolesCount";
            public string Date => "Date";
            public string SectionIds => "SectionIds";
            public string MemberTypes => "MemberTypes";
            public string Who => "Who";
        }




        /// <summary>
        /// Search a palyer.
        /// </summary>
        public class SearchPalyer
        {
            public string UserId => "UserId";
            public string Criteria => "Criteria";
            public string LinkStatus => "LinkStatus";
        }


        /// <summary>
        /// Match operation.
        /// </summary>
        public class MatchOperation
        {
            public string MatchId => "MatchId";
            public string Operation => "Operation"; //0=cancel ; 1=leave ; 2=join
            public string AddToDiary => "AddToDiary";
            public string RemindMe => "RemindMe";
            public string StartPreference => "StartPreference";
            public string CancelReason => "CancelReason";
        }


        /// <summary>
        /// Create A Match.
        /// </summary>
        public class CreateMatch
        {
            public string Name => "Name";
            public string Date => "Date";
            public string Time => "Time";
            public string MaxSlots => "MaxSlots";
            public string FirstTeeTime => "FirstTeeTime";
            public string LastTeeTime => "LastTeeTime";
            public string MeetingTime => "MeetingTime";
            public string MeetingPlace => "MeetingPlace";
            public string OpenInvitation => "OpenInvitation";
            public string IsPublished => "IsPublished";
            public string TeeGap => "TeeGap";
            public string IsQualifier => "IsQualifier";
            public string ClubDiaryVisible => "ClubDiaryVisible";
            public string HolesCount => "HolesCount";
            public string MemberType => "MemberType";
            public string MatchStatus => "MatchStatus";
            public string TeeStartTimeSlot => "TeeStartTimeSlot";
            public string DrawDate => "DrawDate";
            public string Description => "Description";
            public string TeeStartCount => "TeeStartCount";
            public string PlayersPerTee => "PlayersPerTee";
            public string Sections => "Sections";
            public string TeeColours => "TeeColours";
            public string CourseId => "CourseId";
            public string ScoringTypeId => "ScoringTypeId";
            public string MatchTypeId => "MatchTypeId";
            public string Fee => "Cost";
            public string MinHandicap => "MinHandicap";
            public string MaxHandicap => "MaxHandicap";
            public string PlayerAllowance => "PlayerAllowance";
            public string AllowedPlayers => "AllowedPlayers";
            public string LocationId => "LocationId";
            public string MeetingPlaceId => "MeetingPlaceId";

        }

        public class Profile
        {
            public string userid => "userid";
        }

        public class GetLinks
        {
            public string loggedUserId => "loggedUserId";
        }

        public class GetSuggestions
        {
            public string Take => "Take";
            public string Postcode => "Postcode";
        }


        public class EditProfile
        {
            public string Age => "Age";
            public string Gender => "Gender";
            public string Postcode => "Postcode";
            public string IsSmoker => "IsSmoker";
            public string HandiCap => "HandiCap";
            public string MemberType => "MemberType";
            public string Occupation => "Occupation";
            public string PrefferedSection => "PrefferedSection";
            public string Biography => "Biography";
            public string InterestIds => "Interests";
            public string PrefferedHandicapFrom => "PrefferedHandicapFrom";
            public string PrefferedHandicapTo => "PrefferedHandicapTo";
            public string MondayTimeFrom => "MondayTimeFrom";
            public string MondayTimeTo => "MondayTimeTo";
            public string SundayTimeFrom => "SundayTimeFrom";
            public string SundayTimeTo => "SundayTimeTo";
            public string TuesdayTimeFrom => "TuesdayTimeFrom";
            public string TuesdayTimeTo => "TuesdayTimeTo";
            public string WednesdayTimeFrom => "WednesdayTimeFrom";
            public string WednesdayTimeTo => "WednesdayTimeTo";
            public string ThursdayTimeFrom => "ThursdayTimeFrom";
            public string ThursdayTimeTo => "ThursdayTimeTo";
            public string FridayTimeFrom => "FridayTimeFrom";
            public string FridayTimeTo => "FridayTimeTo";
            public string SaturdayTimeFrom => "SaturdayTimeFrom";
            public string SaturdayTimeTo => "SaturdayTimeTo";
            public string Mobile => "Mobile";
            public string Email => "Email";
            public string UserName => "UserName";
            public string Id => "";
            public string UserId => "UserId";
        }


        public class ClubEvents
        {
            public string UserId => "UserId";
            public string StartDate => "StartDate";
            public string EndDate => "EndDate";
            public string EventType => "EventType";

        }


        public class PlayNow
        {
            public string LocationId => "MeetingPlaceId";
            public string ActiveFor => "ActiveFor";
            public string IsWaitingForAPlayer => "IsWaitingForAPlayer";

        }


        public class EventOperation
        {
            public string EventId => "EventId";
            public string ActionType => "ActionType";
            public string ReservedFor => "ReservedFor";

        }

        public class CourseStatus
        {
            public string courseid => "courseid";

        }

        public class MyMatches
        {

            public string StartDate => "StartDate";
            public string EndDate => "EndDate";
            public string Options => "Options";

        }

        public class ClubCompetitions
        {

            public string StartDate => "StartDate";
            public string EndDate => "EndDate";
            public string Invitation => "Invitation";
            public string Joined => "Joined";
            public string OpenInvitation => "OpenInvitation";

        }

        public class SaveNotificationId
        {

            public string NotificationId => "NotificationId";

        }

    }
}
