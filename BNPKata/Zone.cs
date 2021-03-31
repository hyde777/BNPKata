using System;
using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public record Zone
    {
        public int Matricule { get; }
        public int ArgPriceOfInsideTrip { get; }
        private readonly string[] _argStations;
        private readonly IEnumerable<(int ZoneName, int Pricing)> _argTravelTo;

        public Zone(int matricule, int argPriceOfInsideTrip, string[] argStations,
            IEnumerable<(int ZoneName, int Pricing)> argTravelTo)
        {
            Matricule = matricule;
            ArgPriceOfInsideTrip = argPriceOfInsideTrip;
            _argStations = argStations;
            _argTravelTo = argTravelTo;
        }

        public bool ContainStation(string startStation)
        {
            return _argStations.Contains(startStation);
        }

        public (Zone zone, int pricing) CheapestZoneToTravelAndPrice(IEnumerable<Zone> endZones)
        {
            if (endZones == null) return (Zone.Max(), int.MaxValue);
            var orderedEnumerable = _argTravelTo?.OrderBy(x => x.Pricing);
            IEnumerable<Zone> enumerable = endZones.ToArray();
            if (orderedEnumerable != null)
                foreach ((int ZoneName, int Pricing) t in orderedEnumerable)
                {
                    if (enumerable.Any(z => z.Matricule == t.ZoneName))
                        return (enumerable.First(z => z.Matricule == t.ZoneName), t.Pricing);
                }

            return (Zone.Max(), int.MaxValue);
        }

        private static Zone Max()
        {
            return new Zone(int.MaxValue, Int32.MaxValue, null, null);
        }
    }
}