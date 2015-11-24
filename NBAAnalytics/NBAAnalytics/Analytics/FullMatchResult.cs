namespace NBAAnalytics.Analytics
{
    public class FullMatchResult
    {
        public FullMatchResult(string homeTeam, string awayTeam, int homeScore, int awayScore)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeScore = homeScore;
            AwayScore = awayScore;
        }

        public string HomeTeam { get; protected set; }
        public string AwayTeam { get; protected set; }
        public int HomeScore { get; protected set; }
        public int AwayScore { get; protected set; }
    }
}