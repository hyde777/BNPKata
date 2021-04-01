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
            Zone zone1 = new(matricule,100, new []{ startStation, endStation}, null);
            IZones zones = new Zones(new List<Zone>
            {
                zone1
            });

            (Zone startZone, Zone endZone, _) = zones.CheapestTripFrom(startStation, endStation);

            startZone.Should().Be(zone1);
            endZone.Should().Be(zone1);
        }

        [Test]
        public void ShouldChooseCheapestZoneWhenInsideTraveling()
        {
            string startStation = "A";
            string endStation = "B";
            int cheapestPricing = 50;
            Zone zone1 = new(1,100, new []{ startStation, endStation},null);
            Zone cheapestZone = new(2,cheapestPricing, new []{ startStation, endStation}, null);
            IZones zones = new Zones(new List<Zone>
            {
                zone1,
                cheapestZone
            });

            (Zone startZone, Zone endZone, int pricing) = zones.CheapestTripFrom(startStation, endStation);

            startZone.Should().Be(cheapestZone);
            endZone.Should().Be(cheapestZone);
            pricing.Should().Be(cheapestPricing);
        }

        [Test]
        public void ShouldChooseCheapestZoneWhenInsideTravelingWithBothStation()
        {
            string startStation = "A";
            string endStation = "B";
            Zone cheapZoneWithOnlyEndStation = new(1,50, new []{ endStation},null);
            Zone cheapestZoneWithOnlyStartStation = new(2,0, new []{ startStation}, null);
            Zone zoneWithAtLeastBothStation = new(3,100, new []{ startStation, endStation},null);
            IZones zones = new Zones(new List<Zone>
            {
                cheapZoneWithOnlyEndStation,
                cheapestZoneWithOnlyStartStation,
                zoneWithAtLeastBothStation
            });

            (Zone startZone, Zone endZone, _) = zones.CheapestTripFrom(startStation, endStation);

            startZone.Should().Be(zoneWithAtLeastBothStation);
            endZone.Should().Be(zoneWithAtLeastBothStation);
        }
        
        [Test]
        public void ShouldChooseCheapestZonesWithStations()
        {
            string startStation = "A";
            string endStation = "B";
            int zoneMatricule2 = 2;
            int cheapestPricing = 50;
            Zone zone1 = new(1,100, new []{ startStation}, new List<(int ZoneName, int Pricing)>{(zoneMatricule2, cheapestPricing)});
            Zone zone2 = new(zoneMatricule2,60, new []{ endStation}, null);
            IZones zones = new Zones(new List<Zone>
            {
                zone1,
                zone2
            });
        
            (Zone startZone, Zone endZone, int pricing) = zones.CheapestTripFrom(startStation, endStation);
        
            startZone.Should().Be(zone1);
            endZone.Should().Be(zone2);
            pricing.Should().Be(cheapestPricing);
        }

        [Test]
        public void ShouldChooseCheapestZoneOutOfbothInsideAndInsideToOutsideZone()
        {
            string startStation = "A";
            string endStation = "B";
            int zoneMatricule2 = 2;
            int cheapestPricing = 50;
            Zone zone1 = new(1,100, new []{ startStation, endStation}, new List<(int ZoneName, int Pricing)>{(zoneMatricule2, cheapestPricing)});
            Zone zone2 = new(zoneMatricule2,60, new []{ endStation}, null);
            IZones zones = new Zones(new List<Zone>
            {
                zone1,
                zone2
            });
        
            (Zone startZone, Zone endZone, int pricing) = zones.CheapestTripFrom(startStation, endStation);
        
            startZone.Should().Be(zone1);
            endZone.Should().Be(zone2);
            pricing.Should().Be(pricing);
        }
    }
}