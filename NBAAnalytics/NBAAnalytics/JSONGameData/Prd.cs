using System.Runtime.Serialization;

namespace NBAAnalytics.JSONGameData
{
    public class Prd
    {
        [DataMember(Name = "n")]
        public int N { get; set; }

        [DataMember(Name = "s")]
        public string S { get; set; }
    }
}