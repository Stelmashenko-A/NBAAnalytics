namespace NBAAnalytics.Analytics
{
    public static class Finder
    {
        public static bool ContainsOrderedSequence(string str, string subStr)
        {
            
            var strTmp = str.ToLower();
            subStr = subStr.ToLower();
            if (strTmp[0] != subStr[0])
            {
                return false;
            }
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

        public static bool IsAbbreviation(string str, string abb)
        {
            str = str.ToLower();
            abb = abb.ToLower();
            var strs = str.Split(' ');
            if (strs.Length == 1) return false;
            if (strs.Length == 2)
            {
                if (strs[0][0] == abb[0] && strs[1][0] == abb[1])
                {
                    return true;
                }
            }

            if (strs.Length != 2) return false;
            return strs[0][0] == abb[0] && strs[1][0] == abb[1] && strs[2][0] == abb[2];
        }
    }
}
