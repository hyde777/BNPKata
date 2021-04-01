using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public class Zones : IZones
    {
        private readonly IEnumerable<Zone> _zones;

        public Zones(IEnumerable<Zone> zones)
        {
            _zones = zones;
        }

        public (Zone, Zone, int pricing) CheapestTripFrom(string startStation, string endStation)
        {
            Zone inside = CheapestTripWhenInsideaZone(startStation, endStation);
            
            (Zone inside, Zone outside, int pricing) insideToOutside = CheapestTripUsingGoingOutsideTheZone(startStation, endStation);

            if (inside == null)
                return insideToOutside;
            if (inside.PriceOfInsideTrip > insideToOutside.pricing)
                return insideToOutside;
            return (inside, inside, inside.PriceOfInsideTrip);
        }

        private Zone CheapestTripWhenInsideaZone(string startStation, string endStation)
        {
            return _zones
                .Where(z => z.ContainStation(startStation) && z.ContainStation(endStation))
                .OrderBy(x=> x.PriceOfInsideTrip)
                .FirstOrDefault();
        }

        private (Zone z, Zone zone, int pricing) CheapestTripUsingGoingOutsideTheZone(string startStation, string endStation)
        {
            return _zones
                .Where(z => z.ContainStation(startStation))
                .OrderBy(z=> z.CheapestZoneToTravelAndPrice(EndZones(endStation)).pricing)
                .Select(z => (z, z.CheapestZoneToTravelAndPrice(EndZones(endStation)).zone, z.CheapestZoneToTravelAndPrice(EndZones(endStation)).pricing))
                .FirstOrDefault();
        }

        private IEnumerable<Zone> EndZones(string endStation)
        {
            return _zones.Where(x => x.ContainStation(endStation));
        }
    }
}