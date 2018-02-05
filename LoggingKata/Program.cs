using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;
using Geolocation;

namespace LoggingKata
{
    class Program
    {
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var myFile = Environment.CurrentDirectory + "\\Taco_Bell-US-AL-Alabama.csv";
            var lines = File.ReadAllLines(myFile);

            if (lines.Length == 0)
            {
                Console.WriteLine("You must provide a filename as an argument");
                Logger.Fatal("Cannot import without filename specified as an argument");
                Console.ReadLine();
                return;
            }
            if (lines.Length == 1)
            {
                Console.WriteLine("You must provide a filename as an argument");
                Logger.Fatal("Cannot import without filename specified as an argument");
                Console.ReadLine();
                return;
            }

            Logger.Info("Log initialized");

            var parser = new TacoParser();
            var locations = lines.Select(line => parser.Parse(line));
            
            ITrackable locA = null;
            ITrackable locB = null;

            double distance = 0;

            foreach (var a in locations)
            {
                var origin = new Coordinate { Longitude = a.Location.Longitude, Latitude = a.Location.Latitude };
                
                foreach (var b in locations)
                {
                    var destination = new Coordinate { Longitude = b.Location.Longitude, Latitude = b.Location.Latitude };
                    var dist = GeoCalculator.GetDistance(origin, destination);

                    if (dist <= distance) { continue; }
                    distance = dist;
                    locA = a;
                    locB = b;
                }
            }
            Console.WriteLine($"The two taco bells farthest from each other are {locA.Name} and {locB.Name}, and they are {distance} miles apart.");
            Console.WriteLine("Program has ended, press any key to exit");
            Console.ReadLine();
        }
    }
}