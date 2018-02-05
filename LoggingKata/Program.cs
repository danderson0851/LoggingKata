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
        //Why do you think we use ILog?
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
            
            
            ITrackable firstLocation = null;
            ITrackable secondLocation = null;

            double distance = 0;
            
            foreach (var myX in locations)
            {
                Console.WriteLine(myX.Location.Longitude);
                Console.WriteLine(myX.Location.Latitude);
                /*
                 var origin = new Coordinate
                {
                    Longitude = myX.Location.Longitude,
                    Latitude = myX.Location.Latitude
                };*/

                /*
                 foreach (var myY in locations)
                {
                    var destination = new Coordinate
                    {
                        Longitude = myY.Location.Longitude,
                        Latitude = myY.Location.Latitude
                    };

                    var distanceApart = GeoCalculator.GetDistance(origin, destination);
                    if (distanceApart > distance)
                    {
                        distance = distanceApart;
                        firstLocation = x;
                        secondLocation = myY;
                    }
                }*/
            }

            //Console.WriteLine($"{firstLocation},{secondLocation},{distance}");

            Console.WriteLine("Program has ended, press any key to exit");
            Console.ReadLine();
        }
    }
}