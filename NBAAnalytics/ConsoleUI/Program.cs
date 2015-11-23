using System;
using NBAAnalytics;
using Raven.Client.Document;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            var class1 = new DataMiner();
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
            }
        }
    }
}
