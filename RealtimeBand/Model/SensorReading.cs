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

        private static double _bandTemperature;
        public static double BandTemperature
        {
            get
            {
                return _bandTemperature;
            }
            set { _bandTemperature = value; }
        }

        private static long _totalDistance;
        public static long TotalDistance
        {
            get { return _totalDistance; }
            set { _totalDistance = value; }
        }
        private static double _bandSpeed;
        public static double BandSpeed
        {
            get { return _bandSpeed; }
            set { _bandSpeed = value; }
        }
    }
}
