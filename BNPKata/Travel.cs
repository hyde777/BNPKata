using System;
using System.Collections.Generic;

namespace BNPKata
{
    public class Travel : ITravel
    {
        public Travel(IEnumerable<IZone> zones)
        {
        }

        public string Compute(List<Tap> tapsList)
        {
            throw new NotImplementedException();
        }
    }
}