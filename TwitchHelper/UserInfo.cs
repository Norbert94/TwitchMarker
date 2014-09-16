using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TwitchMarker
{
    public class UserInfo
    {
        public JToken stream;
        public JToken game;
        public JToken title;

        public UserInfo(string json)
        {
            JObject jobject = JObject.Parse(json);
            stream = jobject["stream"];
            if(stream.HasValues)
            {
                game = jobject["stream"]["game"];
                title = jobject["stream"]["channel"]["status"];
            }
        }

        public bool streamLive()
        {
            bool Live = true;

            if (!stream.HasValues)
                Live = false;

            return Live;
        }
    }
}
