using System;
using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public class Zone
    {
        private const int NONE_FOUND = int.MaxValue;
        public int Matricule { get; }
        public int PriceOfInsideTrip { get; }
        private readonly string[] _stations;
        private readonly IEnumerable<(int ZoneName, int Pricing)> _outsideLinkedZoneAndPricing;

        public Zone(int matricule, 
            int priceOfInsideTrip, 
            string[] stations,
            IEnumerable<(int ZoneName, int Pricing)> outsideLinkedZoneAndPricing)
        {
            Matricule = matricule;
            PriceOfInsideTrip = priceOfInsideTrip;
            _stations = stations;
            _outsideLinkedZoneAndPricing = outsideLinkedZoneAndPricing;
        }

        public bool ContainStation(string startStation)
        {
            return _stations.Contains(startStation);
        }

        public (Zone zone, int pricing) CheapestZoneToTravelOutside(IEnumerable<Zone> endZones)
        {
            if (endZones == null) return (Zone.NoneFound(), NONE_FOUND);
            var orderedEnumerable = _outsideLinkedZoneAndPricing?.OrderBy(x => x.Pricing);
            IEnumerable<Zone> enumerable = endZones.ToArray();
            if (orderedEnumerable == null) return (Zone.NoneFound(), NONE_FOUND);
            foreach ((int ZoneName, int Pricing) t in orderedEnumerable)
            {
                if (enumerable.Any(z => z.Matricule == t.ZoneName))
                    return (enumerable.First(z => z.Matricule == t.ZoneName), t.Pricing);
            }

            return (Zone.NoneFound(), NONE_FOUND);
        }

        private static Zone NoneFound() => new(NONE_FOUND, NONE_FOUND, null, null);
    }
}