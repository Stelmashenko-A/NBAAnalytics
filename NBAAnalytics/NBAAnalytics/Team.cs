using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NBAAnalytics
{
    public class Team
    {
        [DataMember(Name = "home")]
        public int Home { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "win")]
        public int Win { get; set; }

        [DataMember(Name = "awayTeam")]
        public string AwayTeam { get; set; }

        [DataMember(Name = "scores")]
        public List<int> Scores { get; set; }

        [DataMember(Name = "homeTeam")]
        public string HomeTeam { get; set; }
    }
}