using System.Collections.Generic;

namespace NBAAnalytics.Analytics
{
    public interface IJoiner
    {
        IDictionary<string, string> Join(IList<string> firstList, IList<string> secondList);
    }
}
