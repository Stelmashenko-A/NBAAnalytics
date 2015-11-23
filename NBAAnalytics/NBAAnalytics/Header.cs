using System.Runtime.Serialization;

namespace NBAAnalytics
{
    public class Header
    {
        [DataMember(Name = "img")]
        public string Image { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}