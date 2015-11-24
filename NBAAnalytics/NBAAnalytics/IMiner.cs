using System.Collections.Generic;

namespace NBAAnalytics
{
    public interface IMiner<T>
    {
        IList<T> Mine();
    }
}