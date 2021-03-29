using System.Collections.Generic;

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
        public Zones(IEnumerable<Zone> zones)
        {
            throw new System.NotImplementedException();
        }

        public int From(string startStation)
        {
            throw new System.NotImplementedException();
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