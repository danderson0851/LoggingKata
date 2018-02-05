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

            //TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.
            //HINT:  You'll need two nested forloops

            /*
            ITrackable firstLocation = null;
            ITrackable secondLocation = null;

            double distanceApart = 0;
            
            foreach (var checkLocation in locations)
            {
                var local = new Coordinate {TacoBell.Location.};

            }
            */


            Console.ReadLine();
        }
    }
}