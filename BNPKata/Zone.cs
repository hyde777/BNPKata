using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public record Zone
    {
        public int Matricule { get; }
        public int ArgPriceOfInsideTrip { get; }
        private readonly string[] _argStations;

        public Zone(int matricule, int argPriceOfInsideTrip, string[] argStations,
            IEnumerable<(int ZoneName, int Pricing)> argTravelTo)
        {
            Matricule = matricule;
            ArgPriceOfInsideTrip = argPriceOfInsideTrip;
            _argStations = argStations;
        }

        public bool ContainStation(string startStation)
        {
            return _argStations.Contains(startStation);
        }
    }
}