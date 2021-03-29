using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public class TravelControler : ITravelControler
    {
        private readonly ITravel _travel;
        private readonly ISerializer _serializer;

        public TravelControler(ITravel travel, ISerializer serializer)
        {
            _travel = travel;
            _serializer = serializer;
        }

        public string Price(string inputPath)
        {
            IEnumerable<Tap> tapsList = _serializer.Serialize(inputPath);
            return _travel.Compute(tapsList.ToList());
        }
    }
}