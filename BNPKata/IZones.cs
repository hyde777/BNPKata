using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public interface IZones
    {
        (Zone, Zone) From(string startStation, string endStation);
        int To(string endStation);
        int Cost(Zone startStation, Zone endStation);
    }

    public class Zones : IZones
    {
        private readonly IEnumerable<Zone> _zones;

        public Zones(IEnumerable<Zone> zones)
        {
            _zones = zones;
        }

        public (Zone, Zone) From(string startStation, string endStation)
        {
            Zone inside = _zones
                .Where(z => z.ContainStation(startStation) && z.ContainStation(endStation))
                .OrderBy(x=> x.ArgPriceOfInsideTrip)
                .First();
            //Zone insideToOutside = _zones.Where(z => z.HaveStartStation(startStation) z.LinkedToZoneContainingStation(endStation))
            return (inside, inside);
        }

        public int To(string endStation)
        {
            throw new System.NotImplementedException();
        }

        public int Cost(Zone startStation, Zone endStation)
        {
            throw new System.NotImplementedException();
        }
    }
}