using System;
namespace SharedProject.Classes
{
    public class Enums
    {
        public enum GameView
        {
            Organizer,
            Player,
            Viewer
        }

        public enum GolfLinkAction
        {
            RequestlLink,
            AcceptLink,
            IgnoreLink,
            RemoveLink
        }

        public enum LinkStatus
        {
            Pending = 0,
            Ignored = 1,
            Accepted = 2,
            None = 3
        }


        public enum MemberType
        {
            FiveDay,
            SevenDay,
            BothDay
        }

        public enum JoinOperation
        {
            Cancel = 0,
            Leave = 1,
            Join = 2
        }

        public enum EventOperation
        {
            Join = 0,
            Leave = 1
        }

        public enum SearchType
        {
            ByGameCode,
            ByFields
        }

        //public enum MeetingPlaceType
        //	{
        //	Bar = 0,
        //	Restaurant = 1,
        //	PracticeArea = 2
        //	}


        /// <summary>
        /// Players allowance.
        /// </summary>
        public enum PlayersAllowance
        {
            Open,
            SpecificPlayers,
            GolfLink,
            Preferences,
            GameCode
        }

        public enum PrefferedSection
        {
            Men,
            Ladies,
            None,
            Both
        }

        public enum MatchStatus
        {
            Draft,
            Open,
            Closed,
            Cancelled,
            Drawn,
            Finished
        }

        public enum FromMe
        {
            True,
            False,
            None
        }


        /// <summary>
        /// Who. in Find Match
        /// </summary>
        public enum Who
        {
            AllMembers,
            GolfLinks
        }



        /// <summary>
        /// Event status.
        /// </summary>
        public enum EventStatus
        {
            Draft,
            Open,
            Closed,
            Cancelled,
            Finished
        }


        /// <summary>
        /// MeetingPlace Type.
        /// </summary>
        public enum MeetingPlaceType
        {
            Social,
            Golf,
            PlayNow
        }

        /// <summary>
        /// Event type.
        /// </summary>
        public enum EventType
        {
            Private, //no member can join and this is added to the diary to show that event is happening (i.e a wedding or a birthday party)
            Open
        }


        /// <summary>
        /// Course status enum.
        /// </summary>
        public enum CourseStatusEnum
        {
            Off = 0,
            On = 1,
            Disabled = 2
        }

        /// <summary>
        /// Match options.
        /// </summary>
        public enum MatchOptions
        {
            Joined,
            Created,
            Invited,
            OpenInvitation
        }

        public enum StartPreference
        {
            //it is important that items have specific int values as in 
            //Draw we order people by their start preference
            Early = 0,
            Mid = 1,
            Late = 2
        }

    }
}
