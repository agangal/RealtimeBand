using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeBand.Model
{
    public class SensorReading : ViewModel
    {
        private static bool _isHeartRateReadingAllowed;
        public static bool IsHeartRateReadingAllowed
        {
            get { return _isHeartRateReadingAllowed; }
            set { _isHeartRateReadingAllowed = value; }
        }

        private static int _heartRateReading;
        public static int HeartRateReading
        {
            get { return _heartRateReading; }
            set { _heartRateReading = value; }
        }

        private static string _heartRateReadingQuality;
        public static string HeartRateReadingQuality
        {
            get { return _heartRateReadingQuality; }
            set { _heartRateReadingQuality = value; }
        }


    }
}
