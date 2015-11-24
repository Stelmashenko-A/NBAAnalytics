namespace NBAAnalytics.Cities
{
    public class CityPopulationCsvParser : ICsvParser<CityPopulation>
    {
        public CityPopulation Parse(string str)
        {
            var index = str.IndexOf(',');
            var city = str.Substring(0, index).Trim();
            str = str.Remove(0, index + 1);
            index = str.IndexOf(',');
            var state = str.Substring(0, index).Trim();
            str = str.Remove(0, index + 1);
            str = str.Replace('"', ' ');
            var populationStr = str.Trim().Replace(",","");
            return new CityPopulation(city, state, int.Parse(populationStr));
        }
    }
}