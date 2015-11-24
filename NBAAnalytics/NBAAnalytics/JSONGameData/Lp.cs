using System.Runtime.Serialization;

namespace NBAAnalytics.JSONGameData
{
    public class Lp
    {
        [DataMember(Name = "lp_video")]
        public bool LpVideo { get; set; }

        [DataMember(Name = "condense_bb")]
        public bool CondensedBb { get; set; }

        [DataMember(Name = "visitor")]
        public Media VisitorMedia { get; set; }

        [DataMember(Name = "home")]
        public Media HomeMedia { get; set; }
    }
}