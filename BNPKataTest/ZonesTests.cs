using System.Collections.Generic;
using BNPKata;
using FluentAssertions;
using NUnit.Framework;

namespace BNPKataTest
{
    public class ZonesTests
    {
        [Test]
        public void ShouldChooseZonesOfInsideTravel()
        {
            string startStation = "A";
            string endStation = "B";
            int matricule = 1;
            Zone zone1 = new(matricule,100, new []{ startStation, endStation});
            IZones zones = new Zones(new List<Zone>
            {
                zone1
            });

            (Zone startZone, Zone endZone) = zones.From(startStation, endStation);

            startZone.Should().Be(zone1);
            endZone.Should().Be(zone1);
        }

        [Test]
        public void ShouldChooseCheapestZoneWhenInsideTraveling()
        {
            string startStation = "A";
            string endStation = "B";
            Zone zone1 = new(1,100, new []{ startStation, endStation});
            Zone cheapestZone = new(2,50, new []{ startStation, endStation});
            IZones zones = new Zones(new List<Zone>
            {
                zone1,
                cheapestZone
            });

            (Zone startZone, Zone endZone) = zones.From(startStation, endStation);

            startZone.Should().Be(cheapestZone);
            endZone.Should().Be(cheapestZone);
        }
    }
}