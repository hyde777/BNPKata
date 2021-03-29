using System.Collections.Generic;

namespace BNPKata
{
    public interface ITravel
    {
        string Compute(List<Tap> tapsList);
    }
}