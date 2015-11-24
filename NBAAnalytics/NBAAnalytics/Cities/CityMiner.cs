using System.Collections.Generic;
using System.Linq;

namespace NBAAnalytics.Cities
{
    public class CityCsvMiner:IMiner<CityPopulation>
    {
        private readonly ICsvParser<CityPopulation> _parser;
        private readonly ILineMiner _lineMiner;

        public CityCsvMiner(ILineMiner lineMiner, ICsvParser<CityPopulation> parser)
        {
            _lineMiner = lineMiner;
            _parser = parser;
        }

        public IList<CityPopulation> Mine()
        {
            var strings = _lineMiner.Mine();

            return strings.Select(s => _parser.Parse(s)).ToList();

        }
    }
}