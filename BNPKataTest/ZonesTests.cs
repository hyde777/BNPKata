using System.Collections.Generic;
using BNPKata;
using FluentAssertions;
using NUnit.Framework;

namespace BNPKataTest
{
    public class ZonesTests
    {
        [Test]
        public void ShouldChooseCheapestZoneOfInsideTravel()
        {
            string startStation = "A";
            string endStation = "B";
            int matricule = 1;
            Zone zone1 = new(matricule,100, new []{ startStation, endStation});
            IZones zones = new Zones(new List<Zone>
            {
                zone1,
            });

            var zone = zones.From(startStation, endStation);

            zone.Should().Be(zone);
        }
    }
}