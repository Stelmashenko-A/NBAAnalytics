using System.Collections.Generic;
using System.Linq;
using NBAAnalytics.JSONGameData;

namespace NBAAnalytics.Analytics
{
    public class ShortMatchResultsMiner:IMiner<ShortMatchResult>
    {
        private readonly IList<GameDay> _gameDays;

        public ShortMatchResultsMiner(IList<GameDay> gameDays)
        {
            _gameDays = gameDays;
        }

        public IList<ShortMatchResult> Mine()
        {
            var results = new List<ShortMatchResult>();
            foreach (var game in _gameDays.SelectMany(gameDay => gameDay.Games))
            {
                int awayTeamScore, homeTeamScore;
                string awayTeam, homeTeam;

                if (game.Teams[0].HomeTeam != null)
                {
                    homeTeam = game.Teams[0].HomeTeam;
                    homeTeamScore = game.Teams[0].Scores[0];
                    awayTeam= game.Teams[1].AwayTeam;
                    awayTeamScore = game.Teams[1].Scores[0];
                }
                else
                {
                    homeTeam = game.Teams[1].HomeTeam;
                    homeTeamScore = game.Teams[1].Scores[0];
                    awayTeam = game.Teams[0].AwayTeam;
                    awayTeamScore = game.Teams[0].Scores[0];
                }
                results.Add(new ShortMatchResult(homeTeam,awayTeam,homeTeamScore,awayTeamScore));
            }
            return results;
        }
    }
}
