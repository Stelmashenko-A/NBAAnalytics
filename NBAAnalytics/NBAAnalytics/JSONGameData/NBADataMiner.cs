using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using NBAAnalytics.Analytics;

namespace NBAAnalytics.JSONGameData
{
    public class NBADataMiner : IMiner<GameDay>
    {

        private DateTime _dateTime;
        private readonly int _daysBefore;

        public NBADataMiner(DateTime dateTime, int daysBefore)
        {
            _dateTime = dateTime;
            _daysBefore = daysBefore;
        }

        public IList<GameDay> Mine()
        {
            var gameDays = new List<GameDay>();
            for (var i = 0; i < _daysBefore; i++)
            {
                var gameDay = GetRequest(_dateTime);
                if (gameDay != null)
                {
                    gameDays.Add(gameDay);
                }

                _dateTime = _dateTime.Subtract(new TimeSpan(1, 0, 0, 0));
            }
            return gameDays;
        }

        protected string BuildUrl(DateTime date)
        {
            return "http://data.nba.com/data//json/nbacom/" + date.Year + "/gameline/" + ConvertDataToString(date) +
                   "/games.json";
        }

        protected string ConvertDataToString(DateTime date)
        {
            return date.Year.ToString() + date.Month + date.Day;
        }

        protected GameDay GetRequest(DateTime date)
        {
            var request = WebRequest.Create(BuildUrl(date));

            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                var response = request.GetResponse();
                var dataStream = response.GetResponseStream();
                if (dataStream == null) return null;
                var reader = new StreamReader(dataStream);
                var responseFromServer = reader.ReadToEnd();
                return new JavaScriptSerializer().Deserialize<GameDay>(responseFromServer);
            }
            catch (WebException)
            {
                return null;
            }
        }
    }
}