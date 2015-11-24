using System.Collections.Generic;
using System.Linq;

namespace NBAAnalytics.Analytics
{
    public class NBATeamsJoiner : IJoiner
    {
        public IDictionary<string, string> Join(IList<string> shortList, IList<string> fullList)
        {
            var result = new Dictionary<string, string>();
            foreach (var str in shortList)
            {

                var stringForJoining =
                    fullList.FirstOrDefault(
                        item =>
                            item.ToLower().Substring(0, str.Length) == str.ToLower() ||
                            Finder.ContainsOrderedSequence(item, str) || Finder.IsAbbreviation(item, str));
                if (!string.IsNullOrEmpty(stringForJoining))
                {
                    result.Add(str, stringForJoining);
                }
            }
            return result;
        }
    }
}