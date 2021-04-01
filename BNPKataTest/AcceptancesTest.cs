using System;
using System.Collections;
using System.Collections.Generic;
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
            ITravelControler travelControlerControler = new TravelControler(new Travel(Factory.Zones()), tapDeserializer, customerDeserializer);

            travelControlerControler.Price(inputPath);

            mock.Setup(x => x.Deserialize(It.Is<CustomerSummaries>(cs => Equal(cs, Factory.CustomerSummaries()))));
        }

        private bool Equal(CustomerSummaries cs, CustomerSummaries cs2)
        {
            IOrderedEnumerable<CustomerSummary> customerSummaries = cs.Summaries.OrderBy(i => i.CustomerId);
            IOrderedEnumerable<CustomerSummary> customerSummaries2 = cs2.Summaries.OrderBy(i => i.CustomerId);
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