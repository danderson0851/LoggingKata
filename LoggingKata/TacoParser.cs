using System;
using System.Collections;
using System.Collections.Generic;
using log4net;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {

        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {
            if (string.IsNullOrEmpty(line)) { return null; }
            
            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                Console.WriteLine("something went wrong");
                return null;
            }

            var l1 = Double.Parse(cells[0]);
            var l2 = Double.Parse(cells[1]);
            var tbName = cells[2];

            var experiment = new TacoBell();
            experiment.Name = tbName;
            experiment.Location = new Point(l1, l2);
            
            return experiment;
        }
    }
}