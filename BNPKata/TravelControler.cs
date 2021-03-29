using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public class TravelControler : ITravelControler
    {
        private readonly ITravel _travel;
        private readonly ITapDeserializer _tapDeserializer;

        public TravelControler(ITravel travel, ITapDeserializer tapDeserializer,
            ICustomerSummaryDeserializer customerSummaryDeserializer)
        {
            _travel = travel;
            _tapDeserializer = tapDeserializer;
        }

        public string Price(string inputPath)
        {
            IEnumerable<Tap> tapsList = _tapDeserializer.Serialize(inputPath);
            return _travel.Compute(tapsList.ToList());
        }
    }
}