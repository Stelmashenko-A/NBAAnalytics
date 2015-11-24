using System;

namespace NBAAnalytics
{
    public class Match
    {
        public Match(string concurentTeam, Location location, DateTime date, bool overTime, Score score)
        {
            ConcurentTeam = concurentTeam;
            Location = location;
            Date = date;
            OverTime = overTime;
            Score = score;
        }

        public string ConcurentTeam { get; protected set; }
        public Location Location { get; protected set; }
        public DateTime Date { get; private set; }
        public Score Score { get; private set; }
        public bool OverTime { get; protected set; }
    }
}