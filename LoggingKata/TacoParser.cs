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

            Logger.Info("Going to create new instance of TacoBell");

            try
            {
                var l1 = Double.Parse(cells[0]);
                var l2 = Double.Parse(cells[1]);
                var tbName = cells[2];

                var tacoBell = new TacoBell();
                tacoBell.Name = tbName;
                tacoBell.Location = new Point(l1, l2);

                return tacoBell;
            }
            catch (Exception e)
            {
                Logger.Error($"There was an exception: {e}");
                return null;
            }

            

        }
    }
}