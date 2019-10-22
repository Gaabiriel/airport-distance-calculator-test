using System;

namespace ProgrammingTest.Infra.CrossCutting
{
    public static class DistanceCalculator
    {
        public static double GetDistanceFromLatLonInMl(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371; // Radius of the earth in km
            var dLat = Deg2rad(lat2 - lat1);  // deg2rad below
            var dLon = Deg2rad(lon2 - lon1);
            var a =
              Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(Deg2rad(lat1)) * Math.Cos(Deg2rad(lat2)) *
              Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
              ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distanceKm = R * c; // Distance in km
            var distanceMl = distanceKm / 1.6;
            return distanceMl;
        }

        private static double Deg2rad(double deg)
        {
            return deg * (Math.PI / 180);
        }
    }
}
