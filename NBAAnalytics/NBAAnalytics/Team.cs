using System.Collections.Generic;

namespace NBAAnalytics
{
    public class Team
    {
        public Team(string name)
        {
            Name = name;
            Matches = new List<Match>();
        }

        public string Name { get; protected set; }
        public IList<Match> Matches { get; set; }
    }
}