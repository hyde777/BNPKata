using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public class Factory
    {
        public static IZones Zones()
        {
            int zone1Name = 1;
            int zone2Name = 2;
            int zone3Name = 3;
            int zone4Name = 4;
            string[] stations1 = {"A", "B"};
            string[] stations2 = {"C", "D", "E"};
            string[] stations3 = {"C", "E", "F"};
            string[] stations4 = {"F", "G", "H", "I"};
            IEnumerable<(int name, int priceOfInsideTrip, string[] stations, IEnumerable<(int ZoneName, int Pricing)> travelTo)> zonesData =
                new List<(int name, int priceOfInsideTrip, string[] stations, IEnumerable<(int ZoneName, int Pricing)> travelTo)>
                {
                    (zone1Name, 240, stations1, new[] {(zone2Name, 240), (zone3Name, 280), (zone4Name, 300)}),
                    (zone2Name, 240, stations2, new[] {(zone1Name, 240), (zone3Name, 280), (zone4Name, 300)}),
                    (zone3Name, 200, stations3, new[] {(zone4Name, 200), (zone1Name, 280), (zone2Name, 280)}),
                    (zone4Name, 200, stations4, new[] {(zone3Name, 200), (zone1Name, 300), (zone2Name, 300)})
                };
            IEnumerable<Zone> zones = zonesData.Select(x => new Zone(x.name, x.priceOfInsideTrip, x.stations, x.travelTo));
            return new Zones(zones);
        }

        
    }
}