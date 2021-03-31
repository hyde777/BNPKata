using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public interface IZones
    {
        int From(string startStation);
        int To(string endStation);
        int Cost(string startStation, string endStation);
    }

    public class Zones : IZones
    {
        private readonly IEnumerable<Zone> _zones;

        public Zones(IEnumerable<Zone> zones)
        {
            _zones = zones;
        }

        public int From(string startStation)
        {
            return _zones.First(x => x.ContainStation(startStation)).Matricule;
        }

        public int To(string endStation)
        {
            throw new System.NotImplementedException();
        }

        public int Cost(string startStation, string endStation)
        {
            throw new System.NotImplementedException();
        }
    }
}