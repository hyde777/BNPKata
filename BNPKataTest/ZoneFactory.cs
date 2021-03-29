using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public class ZoneFactory
    {
        public static IEnumerable<IZone> Zones()
        {
            string zone1Name = "1";
            string zone2Name = "2";
            string zone3Name = "3";
            string zone4Name = "4";
            string[] stations1 = {"A", "B"};
            string[] stations2 = {"C", "D", "E"};
            string[] stations3 = {"C", "E", "F"};
            string[] stations4 = {"F", "G", "H", "I"};
            IEnumerable<(string name, int priceOfInsideTrip, string[] stations, IEnumerable<(string ZoneName, int Pricing)>
                travelTo)> zonesData =
                new List<(string name, int priceOfInsideTrip, string[] stations, IEnumerable<(string ZoneName, int Pricing)>
                    travelTo)>
                {
                    (zone1Name, 240, stations1, new[] {(zone3Name, 280), (zone4Name, 300)}),
                    (zone2Name, 240, stations2, new[] {(zone3Name, 280), (zone4Name, 300)}),
                    (zone3Name, 200, stations3, new[] {(zone1Name, 280), (zone2Name, 280)}),
                    (zone4Name, 200, stations4, new[] {(zone1Name, 300), (zone2Name, 300)})
                };
            IEnumerable<IZone> zones = zonesData.Select(x => new Zone(x.name, x.priceOfInsideTrip));
            return zones;
        }

    }
}