using System.Collections.Generic;

namespace BNPKata
{
    public interface ITravel
    {
        Journeys Compute(List<Tap> tapsList);
    }
}