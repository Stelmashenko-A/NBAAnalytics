using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NBAAnalytics
{
    public class Game
    {
        [DataMember(Name = "gid")]
        public string Gid { get; set; }

        [DataMember(Name = "st")]
        public int St { get; set; }

        [DataMember(Name = "ot")]
        public int Ot { get; set; }

        [DataMember(Name = "game_url")]
        public string GameUrl { get; set; }

        [DataMember(Name = "recap")]
        public string Recap { get; set; }

        [DataMember(Name = "qts")]
        public List<int> Qts { get; set; }

        [DataMember(Name = "prd")]
        public Prd Prd { get; set; }

        [DataMember(Name = "broadcaster")]
        public Broadcaster Broadcaster { get; set; }

        [DataMember(Name = "h1")]
        public Header Header { get; set; }

        [DataMember(Name = "is_TNT")]
        public bool IsTnt { get; set; }

        [DataMember(Name = "lp")]
        public Lp Lp { get; set; }

        [DataMember(Name = "teams")]
        public List<Team> Teams { get; set; }
    }
}