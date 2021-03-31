using System.Collections.Generic;
using BNPKata;
using FluentAssertions;
using NUnit.Framework;

namespace BNPKataTest
{
    public class ZonesTests
    {
        [Test]
        public void ShouldKnowWhichZoneIsStationA()
        {
            IZones zones = new Zones(new List<Zone>
            {
                new Zone(1,0, new []{"A", "B", "C"})
            });

            int zone = zones.From("A");

            zone.Should().Be(1);
        }

        [Test]
        public void ShouldKnowWhichZoneIsStationB()
        {
            IZones zones = new Zones(new List<Zone>
            {
                new Zone(2,0, new []{ "B", "C"})
            });

            int zone = zones.From("B");

            zone.Should().Be(2);
        }
    }
}