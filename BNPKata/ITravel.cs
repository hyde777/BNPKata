using System.Collections.Generic;

namespace BNPKata
{
    public interface ITravel
    {
        CustomerSummaries Compute(List<Tap> tapsList);
    }
}