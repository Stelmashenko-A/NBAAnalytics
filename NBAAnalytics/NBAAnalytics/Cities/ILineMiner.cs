using System.Collections.Generic;

namespace NBAAnalytics.Cities
{
    public interface ILineMiner
    {
        IList<string> Mine();
    }
}