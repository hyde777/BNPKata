using System;
using System.Collections;
using System.IO;
using System.Linq;
using BNPKata;
using FluentAssertions;
using Microsoft.DotNet.InternalAbstractions;
using Moq;
using NUnit.Framework;

namespace BNPKataTest
{
    public class AcceptancesTests
    {
        [Test]
        public void AcceptanceTest()
        {
            string inputPath = Path.Combine(AppContext.BaseDirectory, "Input1.json");
            string testOutput = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Output1.json"));
            
            ITapDeserializer tapDeserializer = new JsonTapDeserializer();
            Mock<ICustomerSummaryDeserializer> mock = new Mock<ICustomerSummaryDeserializer>();
            ICustomerSummaryDeserializer customerDeserializer = mock.Object;
            ITravelControler travelControlerControler = new TravelControler(new Travel(ZoneFactory.Zones()), tapDeserializer, customerDeserializer);

            string pricerOutput = travelControlerControler.Price(inputPath);

            mock.Setup(x => x.Deserialize(It.Is<CustomerSummaries>(cs => cs.Equals(CustomerSummaries()))));
        }

        private static CustomerSummaries CustomerSummaries()
        {
            CustomerSummaries customerSummaries = new CustomerSummaries
            {
                Summaries = new[]
                {
                    new CustomerSummary
                    {
                        CustomerId = 1,
                        TotalCostInCents = 480,
                        Trips = new[]
                        {
                            new Trips
                            {
                                StationStart = "A",
                                StationEnd = "D",
                                StartedJourneyAt = 1572242400,
                                CostInCents = 240,
                                ZoneFrom = 1,
                                ZoneTo = 2
                            },
                            new Trips
                            {
                                StationStart = "D",
                                StationEnd = "A",
                                StartedJourneyAt = 1572282000,
                                CostInCents = 240,
                                ZoneFrom = 1,
                                ZoneTo = 2
                            }
                        }
                    }
                }
            };
            return customerSummaries;
        }
    }
}