using System.Collections.Generic;
using BNPKata;
using FluentAssertions;
using NUnit.Framework;

namespace BNPKataTest
{
    public class ZoneTest
    {
        [Test]
        public void ShouldFindTheCheapestTripBetween2Zone()
        {
            string startStation = "A";
            string endStation = "B";
            int cheapestZoneMatricule = 2;
            int cheapestPricing = 50;
            (int matricule, int pricing) cheapestZoneAndPricing = (cheapestZoneMatricule, cheapestPricing);
            List<(int ZoneName, int Pricing)> outsideLinkedZoneAndPricing = new() {cheapestZoneAndPricing};
            Zone zone = new(1,100, new []{ startStation}, outsideLinkedZoneAndPricing);

            (Zone zone, int pricing) cheapestZoneToTravelAndPrice = zone.CheapestZoneToTravelOutside(
                new List<Zone>{new Zone(cheapestZoneMatricule, int.MaxValue, new []{endStation}, null)});

            cheapestZoneToTravelAndPrice.zone.Matricule.Should().Be(cheapestZoneMatricule);
            cheapestZoneToTravelAndPrice.pricing.Should().Be(cheapestZoneAndPricing.pricing);
        }

        [Test]
        public void ShouldFindTheCheapestTripBetween2ZoneBis()
        {
            string startStation = "A";
            string endStation = "B";
            int cheapestZoneMatricule = 2;
            int cheapestPricing = 50;
            (int matricule, int pricing) cheapestZoneAndPricing = (cheapestZoneMatricule, cheapestPricing);
            (int matricule, int pricing) otherZoneAndPricing = (4, cheapestPricing + 30);
            List<(int ZoneName, int Pricing)> outsideLinkedZoneAndPricing = new() {cheapestZoneAndPricing, otherZoneAndPricing};
            Zone zone = new(1,100, new []{ startStation}, outsideLinkedZoneAndPricing);

            (Zone zone, int pricing) cheapestZoneToTravelAndPrice = zone.CheapestZoneToTravelOutside(
                new List<Zone>
                {
                    new Zone(cheapestZoneMatricule, int.MaxValue, new []{endStation}, null),
                    new Zone(otherZoneAndPricing.matricule, int.MaxValue, new []{endStation}, null)
                });

            cheapestZoneToTravelAndPrice.zone.Matricule.Should().Be(cheapestZoneMatricule);
            cheapestZoneToTravelAndPrice.pricing.Should().Be(cheapestZoneAndPricing.pricing);
        }
        
        [Test]
        public void ShouldFindTheCheapestTripBetween2ZoneTer()
        {
            string startStation = "A";
            string endStation = "B";
            int cheapZoneMatricule = 2;
            int freeZoneMatricule = 7;
            int freePricing = 0;
            int cheapPricing = freePricing + 40;
            (int matricule, int pricing) freeZoneAndPricing = (freeZoneMatricule, freePricing);
            (int matricule, int pricing) cheapZoneAndPricing = (cheapZoneMatricule, cheapPricing);
            (int matricule, int pricing) otherZoneAndPricing = (4, cheapPricing + 30);
            List<(int ZoneName, int Pricing)> outsideLinkedZoneAndPricing = new() {freeZoneAndPricing, cheapZoneAndPricing, otherZoneAndPricing};
            Zone zone = new(1,100, new []{ startStation}, outsideLinkedZoneAndPricing);

            (Zone zone, int pricing) cheapestZoneToTravelAndPrice = zone.CheapestZoneToTravelOutside(
                new List<Zone>
                {
                    new Zone(cheapZoneMatricule, int.MaxValue, new []{endStation}, null),
                    new Zone(otherZoneAndPricing.matricule, int.MaxValue, new []{endStation}, null),
                    new Zone(freeZoneMatricule, int.MaxValue, new []{endStation}, null)
                });

            cheapestZoneToTravelAndPrice.zone.Matricule.Should().Be(freeZoneMatricule);
            cheapestZoneToTravelAndPrice.pricing.Should().Be(freeZoneAndPricing.pricing);
        }
    }
}