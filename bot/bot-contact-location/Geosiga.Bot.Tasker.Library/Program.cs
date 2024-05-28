using Newtonsoft.Json.Linq;
using System;
using System.Configuration;

namespace Geosiga.Bot.Tasker.Library
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = ConfigurationManager.AppSettings["token"];
            // string token = "6261428381:AAEMLcnwz-ZoXDk1cAS7qbtTZXiRef4Rz1E";
            Engine.Start(token);
        }
    }
}
