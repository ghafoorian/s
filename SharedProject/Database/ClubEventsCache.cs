
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace SharedProject
{
    public class ClubEventsCache
    {

        public ClubEventsCache()
        {

        }

        public List<ClubEvents_Model> RetriveClubeEvents()
        {

            if (!string.IsNullOrEmpty(UserHolder.MyMatches))
            {
                var list = JToken.Parse(UserHolder.ClubEvents).SelectToken("").ToString();
                return JsonConvert.DeserializeObject<List<ClubEvents_Model>>(list);
            }
            else
            {
                return new List<ClubEvents_Model>();
            }
        }
    }
}
