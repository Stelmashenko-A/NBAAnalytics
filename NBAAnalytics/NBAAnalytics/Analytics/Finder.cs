using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAAnalytics.Analytics
{
    public static class Finder
    {
        public static bool ContainsOrderedSequence(string str, string subStr)
        {
            var strTmp = str;
            var result = true;
            for (var i = 0; i < subStr.Length; i++)
            {
                var index = strTmp.IndexOf(subStr[i]);
                if (index == -1)
                {
                    result = false;
                    break;
                    
                }
                strTmp = str.Remove(0, index + 1);
            }
            return result;
        }
    }
}
