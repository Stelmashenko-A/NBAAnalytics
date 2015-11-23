using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NBAAnalytics
{
    public class Media
    {
        [DataMember(Name = "audio")]
        public Dictionary<string, bool> Audio { get; set; }

        [DataMember(Name = "video")]
        public Dictionary<string, bool> Video { get; set; }
    }
}