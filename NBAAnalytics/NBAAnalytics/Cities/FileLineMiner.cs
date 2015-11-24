using System.Collections.Generic;
using System.IO;

namespace NBAAnalytics.Cities
{
    public class FileLineMiner : ILineMiner
    {
        private readonly string _fileName;

        public FileLineMiner(string fileName)
        {
            _fileName = fileName;
        }

        public IList<string> Mine()
        {
            var result = new List<string>();
            using (var file = new StreamReader(_fileName))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }
            return result;
        }
    }
}