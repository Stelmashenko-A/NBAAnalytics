using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NBAAnalytics.JSONGameData
{
    public class GameDay
    {
        [DataMember(Name = "dt")]
        public int Dt { get; set; }

        [DataMember(Name = "nurl")]
        public string Nurl { get; set; }

        [DataMember(Name = "today")]
        public int Today { get; set; }

        [DataMember(Name = "mid")]
        public long Mid { get; set; }

        [DataMember(Name = "pi")]
        public int Pi { get; set; }

        [DataMember(Name = "games")]
        public List<Game> Games { get; set; }
    }
}