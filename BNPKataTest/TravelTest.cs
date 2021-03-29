using System;
using System.Collections.Generic;
using System.IO;
using BNPKata;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BNPKataTest
{
    public class TravelTest
    {
        [Test]
        public void CreateTripsAcceptance()
        {
            ITravel travel = new Travel(new Zones(new List<Zone> {new("1", 200, new []{"A", "B"})}));

            CustomerSummaries compute = travel.Compute(new List<Tap>
            {
                new()
                {
                    Station = "A",
                    CustomerId = 1,
                    UnixTimeStamp = 1
                },
                new()
                {
                    Station = "B",
                    CustomerId = 1,
                    UnixTimeStamp = 2
                },
            });

            compute.Should().Be(new CustomerSummaries {Summaries = new[]
            {
                new CustomerSummary
                {
                    CustomerId = 1,
                    TotalCostInCents = 200,
                    Trips = new []
                    {
                        new Trip
                        {
                            StartedJourneyAt = 1,
                            StationStart = "A",
                            StationEnd = "B",
                            ZoneFrom = 1,
                            ZoneTo = 1,
                            CostInCents = 200
                        }
                    }
                }
            }});
        }
    }
}