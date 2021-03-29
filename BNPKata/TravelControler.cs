using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public class TravelControler : ITravelControler
    {
        private readonly ITravel _travel;
        private readonly ITapDeserializer _tapDeserializer;
        private readonly ICustomerSummaryDeserializer _customerSummaryDeserializer;

        public TravelControler(ITravel travel, ITapDeserializer tapDeserializer,
            ICustomerSummaryDeserializer customerSummaryDeserializer)
        {
            _travel = travel;
            _tapDeserializer = tapDeserializer;
            _customerSummaryDeserializer = customerSummaryDeserializer;
        }

        public void Price(string inputPath)
        {
            IEnumerable<Tap> tapsList = _tapDeserializer.Serialize(inputPath);
            CustomerSummaries compute = _travel.Compute(tapsList.ToList());
            _customerSummaryDeserializer.Deserialize(compute);
        }
    }
}