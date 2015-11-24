namespace NBAAnalytics
{
    public class Score
    {
        public Score(int home, int guest)
        {
            Guest = guest;
            Home = home;
        }

        public int Home { get; protected set; }
        public int Guest { get; protected set; }
    }
}