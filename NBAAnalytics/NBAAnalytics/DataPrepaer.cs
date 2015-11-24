using System;
using System.Collections.Generic;
using System.Linq;
using NBAAnalytics.JSONGameData;

namespace NBAAnalytics
{
    public class DataPrepaer
    {
        public IList<Team> Prepare(IList<GameDay> gemaDays)
        {
            var result = new List<Team>();
            foreach (var gemaDay in gemaDays)
            {
                foreach (var game in gemaDay.Games)
                {
                    if (game.Teams[0].HomeTeam != null)
                    {
                        if (!result.Select(x => x.Name).Contains(game.Teams[0].HomeTeam))
                        {
                            result.Add(new Team(game.Teams[0].HomeTeam));
                        }
                        if (!result.Select(x => x.Name).Contains(game.Teams[1].AwayTeam))
                        {
                            result.Add(new Team(game.Teams[1].AwayTeam));
                        }
                        result.First(x => x.Name == game.Teams[0].HomeTeam)
                            .Matches.Add(new Match(game.Teams[1].AwayTeam, Location.Home, GenDateTime(gemaDay.Dt),
                                game.Ot != 0, new Score(game.Teams[0].Scores[0], game.Teams[1].Scores[0])));
                        result.First(x => x.Name == game.Teams[1].AwayTeam)
                            .Matches.Add(new Match(game.Teams[0].HomeTeam, Location.Guest, GenDateTime(gemaDay.Dt),
                                game.Ot != 0, new Score(game.Teams[1].Scores[0], game.Teams[0].Scores[0])));
                    }
                    else
                    {
                        if (!result.Select(x => x.Name).Contains(game.Teams[0].AwayTeam))
                        {
                            result.Add(new Team(game.Teams[0].AwayTeam));
                        }
                        if (!result.Select(x => x.Name).Contains(game.Teams[1].HomeTeam))
                        {
                            result.Add(new Team(game.Teams[1].HomeTeam));
                        }
                        result.First(x => x.Name == game.Teams[0].AwayTeam)
                            .Matches.Add(new Match(game.Teams[1].HomeTeam, Location.Guest, GenDateTime(gemaDay.Dt),
                                game.Ot != 0, new Score(game.Teams[1].Scores[0], game.Teams[0].Scores[0])));
                        result.First(x => x.Name == game.Teams[1].HomeTeam)
                            .Matches.Add(new Match(game.Teams[0].AwayTeam, Location.Home, GenDateTime(gemaDay.Dt),
                                game.Ot != 0, new Score(game.Teams[0].Scores[0], game.Teams[1].Scores[0])));
                    }
                }
            }
            return result;
        }

        protected DateTime GenDateTime(int str)
        {
            var day = str%100;
            str /= 100;
            var month = str%100;
            str /= 100;
            var year = str;
            return new DateTime(year, month, day);
        }
    }
}