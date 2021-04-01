using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public class TravelControler : ITravelControler
    {
        private readonly ITravel _travel;
        private readonly ITapDeserializer _tapDeserializer;
        private readonly IJourneySerializer _journeySerializer;
        private readonly IPrinter _printer;

        public TravelControler(ITravel travel,
            ITapDeserializer tapDeserializer,
            IJourneySerializer journeySerializer, 
            IPrinter printer)
        {
            _travel = travel;
            _tapDeserializer = tapDeserializer;
            _journeySerializer = journeySerializer;
            _printer = printer;
        }

        public void Price(string inputPath, string outputPath)
        {
            IEnumerable<Tap> tapsList = _tapDeserializer.Serialize(inputPath);
            Journeys compute = _travel.Compute(tapsList.ToList());
            string customerSummariesSerialized = _journeySerializer.Serialize(compute);
            _printer.Print(customerSummariesSerialized, outputPath);
        }
    }
}