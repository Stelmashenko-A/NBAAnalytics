using System.Runtime.Serialization;

namespace NBAAnalytics
{
    public class Broadcaster
    {
        [DataMember(Name = "is_national")]
        public bool IsNational { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}