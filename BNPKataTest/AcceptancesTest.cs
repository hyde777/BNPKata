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
            ITravelControler travelControlerControler = new TravelControler(new Travel(Factory.Zones()), tapDeserializer, customerDeserializer);

            travelControlerControler.Price(inputPath);

            mock.Setup(x => x.Deserialize(It.Is<CustomerSummaries>(cs => cs.Equals(Factory.CustomerSummaries()))));
        }
    }
}