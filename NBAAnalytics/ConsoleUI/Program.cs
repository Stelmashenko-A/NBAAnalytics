using System;
using System.Collections.Generic;
using System.Linq;
using NBAAnalytics;
using NBAAnalytics.Analytics;
using NBAAnalytics.Cities;
using NBAAnalytics.JSONGameData;
using Raven.Client.Document;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main()
        {
            /* var class1 = new NBADataMiner();
             var store = new DocumentStore
             {
                 Url = "http://localhost:8081/",
                 DefaultDatabase = "NBA"
             };
             store.Initialize();
             for (var i = 0; i < 20; i++)
             {
                 var result = class1.Mine(DateTime.Today.Subtract(new TimeSpan(i*100, 0, 0, 0)), 100);
                 using (var session = store.OpenSession())
                 {
                     foreach (var gameDay in result)
                     {
                         session.Store(gameDay);
                     }
                     session.SaveChanges();
                 }
                 Console.Beep();
             }*/
            var store = new DocumentStore
            {
                Url = "http://localhost:8081/",
                DefaultDatabase = "NBA"
            };
            store.Initialize();
            IList<GameDay> gameDays;
            using (var session = store.OpenSession())
            {
                gameDays = session.Query<GameDay>().ToList();

            }
            var nbaAnalizer = new NBAAnalizer(new ShortMatchResultsMiner(gameDays),
                new CityCsvMiner(new FileLineMiner(@"C:\Users\Andrew\Downloads\Top5000Population.csv"), new CityPopulationCsvParser()), new NBATeamsJoiner());
            var results = nbaAnalizer.GetFullMatchResults();
            using (var session = store.OpenSession())
            {
                foreach (var fullMatchResult in results)
                {
                    session.Store(fullMatchResult);
                }
                session.SaveChanges();

            }
        }
    }
}