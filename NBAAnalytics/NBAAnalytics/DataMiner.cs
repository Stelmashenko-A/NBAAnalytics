using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace NBAAnalytics
{
    public class DataMiner
    {
        public IList<GameDay> Mine(DateTime dateTime, int days)
        {
            var gameDays = new List<GameDay>();
            for (var i = 0; i < days; i++)
            {
                var gameDay = GetRequest(dateTime);
                if (gameDay != null)
                {
                    gameDays.Add(gameDay);
                }

                dateTime = dateTime.Subtract(new TimeSpan(1, 0, 0, 0));
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

        public GameDay GetRequest(DateTime date)
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