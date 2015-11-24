using System.Collections.Generic;
using System.Linq;
using NBAAnalytics.Cities;

namespace NBAAnalytics.Analytics
{
    public class NBAAnalizer
    {
        private readonly IMiner<ShortMatchResult> _shortMatchResultsMiner;
        private readonly IMiner<CityPopulation> _cityMiner;
        private readonly IJoiner _joiner;

        public NBAAnalizer(IMiner<ShortMatchResult> shortMatchResultsMiner, IMiner<CityPopulation> cityMiner, IJoiner joiner)
        {
            _shortMatchResultsMiner = shortMatchResultsMiner;
            _cityMiner = cityMiner;
            _joiner = joiner;
        }

        public IList<FullMatchResult> GetFullMatchResults()
        {
            var shortMatchResults = _shortMatchResultsMiner.Mine();
            IList<string> teams = new List<string>();

            foreach (var shortMatchResult in shortMatchResults)
            {
                if (!teams.Contains(shortMatchResult.HomeTeam))
                {
                   teams.Add(shortMatchResult.HomeTeam); 
                }
                if (!teams.Contains(shortMatchResult.AwayTeam))
                {
                    teams.Add(shortMatchResult.AwayTeam);
                }
            }

            var cities = _cityMiner.Mine().Select(item => item.City).ToList();
            var joinedStrings = _joiner.Join(teams, cities);
            var result = new List<FullMatchResult>();

            foreach (var shortMatchResult in shortMatchResults)
            {
                var homeTeam = shortMatchResult.HomeTeam;
                var awayTeam = shortMatchResult.AwayTeam;
                if (joinedStrings.ContainsKey(homeTeam))
                {
                    homeTeam = joinedStrings[homeTeam];
                }
                if (joinedStrings.ContainsKey(awayTeam))
                {
                    awayTeam = joinedStrings[awayTeam];
                }
                result.Add(new FullMatchResult(homeTeam,awayTeam,shortMatchResult.HomeScore,shortMatchResult.AwayScore));
            }
            return result;
        } 
    }
}
