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
        public void RenameMe()
        {
            Mock<ITravel> mockTravel = new();
            ISerializer serializer = new MyJsonSerializer();

            ITravelControler travelControler = new TravelControler(mockTravel.Object, serializer);

            string inputPath = Path.Combine(AppContext.BaseDirectory, "InputTap.json");
            travelControler.Price(inputPath);
            
            mockTravel.Verify(x => x.Compute(new List<Tap>
            {
                new() {UnixTimeStamp = @"1572242400", CustomerId = @"1", Station = @"A"}
            }));
        }
    }
}