using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public class TravelControler : ITravelControler
    {
        private readonly ITravel _travel;
        private readonly ITapDeserializer _tapDeserializer;
        private readonly ICustomerSummaryDeserializer _customerSummaryDeserializer;
        private readonly IPrinter _printer;

        public TravelControler(ITravel travel,
            ITapDeserializer tapDeserializer,
            ICustomerSummaryDeserializer customerSummaryDeserializer, 
            IPrinter printer)
        {
            _travel = travel;
            _tapDeserializer = tapDeserializer;
            _customerSummaryDeserializer = customerSummaryDeserializer;
            _printer = printer;
        }

        public void Price(string inputPath, string outputPath)
        {
            IEnumerable<Tap> tapsList = _tapDeserializer.Serialize(inputPath);
            Journeys compute = _travel.Compute(tapsList.ToList());
            string customerSummariesSerialized = _customerSummaryDeserializer.Serialize(compute);
            _printer.Print(customerSummariesSerialized, outputPath);
        }
    }
}