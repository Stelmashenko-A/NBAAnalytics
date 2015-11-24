namespace NBAAnalytics.Cities
{
    public class CityPopulation
    {
        public CityPopulation(string city, string state, int population)
        {
            City = city;
            State = state;
            Population = population;
        }

        public string City { get; protected set; }
        public string State { get; protected set; }
        public int Population { get; protected set; }
    }
}