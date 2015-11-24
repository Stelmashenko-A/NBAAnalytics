using System.Collections.Generic;
using System.Linq;
using Raven.Client;

namespace NBAAnalytics
{
    public class RavenMiner<T>:IMiner<T>
    {
        private readonly IDocumentStore _documentStore;

        public RavenMiner(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public IList<T> Mine()
        {
            using (var session = _documentStore.OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }
    }
}
