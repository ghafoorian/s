using System;
namespace SharedProject.Classes
{
    public class ReceivedApi
    {
        public class MatchResult
        {

            public string Id {
                get;
                set;
            }

            public string Title {
                get;
                set;
            }

            public string Image {
                get;
                set;
            }

            public string Date {
                get;
                set;
            }

            public string Percentage {
                get;
                set;
            }
        }

        public class GamesList
        {

            public string ID {
                get;
                set;
            }
            public string Date {
                get;
                set;
            }

            public string StartTime {
                get;
                set;
            }

            public string StopTime {
                get;
                set;
            }

            public string Avatar {
                get;
                set;
            }

            public string GameName {
                get;
                set;
            }

            public string Where {
                get;
                set;
            }

            public string Drift {
                get;
                set;
            }

            public string status {
                get;
                set;
            }
        }

        public class NotifList
        {

            public string ID {
                get;
                set;
            }
            public string Date {
                get;
                set;
            }

            public string Message {
                get;
                set;
            }

            public string Avatar {
                get;
                set;
            }
        }

        public class VideoList
        {

            public string ID {
                get;
                set;
            }
            public string Time {
                get;
                set;
            }

            public string Title {
                get;
                set;
            }

            public string Thumb {
                get;
                set;
            }
        }

    }
}
