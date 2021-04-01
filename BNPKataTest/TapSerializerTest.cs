using System;
using System.Collections.Generic;
using System.IO;
using BNPKata;
using Moq;
using NUnit.Framework;

namespace BNPKataTest
{
    public class TravelControllerTest
    {
        [Test]
        public void SerializeOneTap()
        {
            Mock<ITravel> mockTravel = new();
            ITapDeserializer tapDeserializer = new JsonTapDeserializer();

            ITravelControler travelControler = new TravelControler(mockTravel.Object, tapDeserializer, Mock.Of<ICustomerSummaryDeserializer>(), Mock.Of<IPrinter>());

            string inputPath = Path.Combine(AppContext.BaseDirectory, "InputTap.json");
            travelControler.Price(inputPath, string.Empty);
            
            mockTravel.Verify(x => x.Compute(new List<Tap>
            {
                new() {UnixTimeStamp = 1572242400, CustomerId = 1, Station = @"A"}
            }));
        }
    }
}