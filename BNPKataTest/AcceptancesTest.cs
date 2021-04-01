using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BNPKata;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace BNPKataTest
{
    public class AcceptancesTests
    {
        [Test]
        public void AcceptanceTest()
        {
            string inputPath = Path.Combine(AppContext.BaseDirectory, "Input1.json");
            
            ITapDeserializer tapDeserializer = new JsonTapDeserializer();
            Mock<IJourneySerializer> mock = new();
            IJourneySerializer customerSerializer = mock.Object;
            ITravelControler travelControlerControler = new TravelControler(new Travel(Factory.Zones()), tapDeserializer, customerSerializer, Mock.Of<IPrinter>());

            travelControlerControler.Price(inputPath, String.Empty);

            mock.Setup(x => x.Serialize(It.Is<Journeys>(cs => Equal(cs, CustomerSummaries()))));
        }
        private Journeys CustomerSummaries()
        {
            Journeys journeys = new Journeys
            {
                CustomerSummaries = new[]
                {
                    new CustomerSummary
                    {
                        CustomerId = 1,
                        TotalCostInCents = 480,
                        Trips = new[]
                        {
                            new Trip
                            {
                                StationStart = "A",
                                StationEnd = "D",
                                StartedJourneyAt = 1572242400,
                                CostInCents = 240,
                                ZoneFrom = 1,
                                ZoneTo = 2
                            },
                            new Trip
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
            return journeys;
        }
        
        [Test]
        public void AcceptanceWithGivenFiles()
        {
            string inputPath = Path.Combine(AppContext.BaseDirectory, "Input2.json");
            string testOutput = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Output2.json"));
            
            ITapDeserializer tapDeserializer = new JsonTapDeserializer();
            IJourneySerializer customerSerializer = new JsonJourneySerializer();
            Mock<IPrinter> mock = new();
            ITravelControler travelControlerControler = new TravelControler(new Travel(Factory.Zones()), tapDeserializer, customerSerializer, mock.Object);

            travelControlerControler.Price(inputPath, string.Empty);
            
            mock.Verify(x => x.Print(It.Is<string>(x => EqualJson(x, testOutput)), It.IsAny<string>()));
        }

        private static bool EqualJson(string x, string expected)
        {
            JToken jToken = JToken.Parse(x);
            JToken token = JToken.Parse(expected);
            return JToken.DeepEquals(token, jToken);
        }

        private bool Equal(Journeys cs, Journeys cs2)
        {
            IOrderedEnumerable<CustomerSummary> customerSummaries = cs.CustomerSummaries.OrderBy(i => i.CustomerId);
            IOrderedEnumerable<CustomerSummary> customerSummaries2 = cs2.CustomerSummaries.OrderBy(i => i.CustomerId);
            IEnumerable<(CustomerSummary First, CustomerSummary Second)> valueTuples = customerSummaries.Zip(customerSummaries2);
            foreach (var summaries in valueTuples)
            {
                bool b = summaries.First.CustomerId == summaries.Second.CustomerId;
                bool b1 = summaries.First.TotalCostInCents == summaries.Second.TotalCostInCents;
                bool sequenceEqual = summaries.First.Trips.OrderBy(trip => trip.StartedJourneyAt)
                    .SequenceEqual(summaries.Second.Trips.OrderBy(t => t.StartedJourneyAt));

                bool equal = b || b1 || sequenceEqual;
                if (equal is false) return false;
            }

            return true;
        }
    }
}