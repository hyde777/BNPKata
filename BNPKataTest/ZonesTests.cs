using System.Collections.Generic;
using BNPKata;
using FluentAssertions;
using NUnit.Framework;

namespace BNPKataTest
{
    public class ZonesTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public void ShouldKnowWhichZoneIsStation(int matricule)
        {
            string stationAsked = "A";
            IZones zones = new Zones(new List<Zone>
            {
                new(matricule,0, new []{ stationAsked})
            });

            int zone = zones.From(stationAsked);

            zone.Should().Be(matricule);
        }
    }
}