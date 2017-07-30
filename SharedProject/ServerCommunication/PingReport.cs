namespace SharedProject
{
    public static class PingReport
    {
        public static string Report(PingServer.PingResult pingresult)
        {
            switch (pingresult)
            {
                case PingServer.PingResult.Ok:
                    return "ok";

                case PingServer.PingResult.Disconnect:
                    return "You Are Disconected from Internet.";

                case PingServer.PingResult.ServerErr:
                    return "Oops !!! Server Error";

                default:
                    return "";
            }
        }
    }
}