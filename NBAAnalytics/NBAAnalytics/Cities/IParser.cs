namespace NBAAnalytics.Cities
{
    public interface IParser<out T>
    {
        T Parse(string str);
    }
}