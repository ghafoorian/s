
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace SharedProject
{
    public class MyMatchesCache
    {

        public MyMatchesCache()
        {

        }
        public List<GameView_Model> RetriveMyMatches()
        {
            if (!string.IsNullOrEmpty(UserHolder.MyMatches))
            {
                var list = JToken.Parse(UserHolder.MyMatches).SelectToken("").ToString();
                return JsonConvert.DeserializeObject<List<GameView_Model>>(list);
            }
            else
            {
                return new List<GameView_Model>();
            }
        }
    }
}
