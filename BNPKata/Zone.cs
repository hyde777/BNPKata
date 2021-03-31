using System.Linq;

namespace BNPKata
{
    public class Zone
    {
        public int Matricule { get; }
        private readonly string[] _argStations;

        public Zone(int matricule, int argPriceOfInsideTrip, string[] argStations)
        {
            Matricule = matricule;
            _argStations = argStations;
        }

        public bool ContainStation(string startStation)
        {
            return _argStations.Contains(startStation);
        }
    }
}