using System;
using System.Collections;
using System.IO;
using System.Linq;
using BNPKata;
using FluentAssertions;
using Microsoft.DotNet.InternalAbstractions;
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
            ISerializer serializer = new MyJsonSerializer();
            ITravelControler travelControlerControler = new TravelControler(new Travel(ZoneFactory.Zones()), serializer);

            string pricerOutput = travelControlerControler.Price(inputPath);
            
            pricerOutput.Should().Be(testOutput);
        }

    }
}