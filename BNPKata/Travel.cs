using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BNPKata
{
    public class Travel : ITravel
    {
        private readonly IZones _zones;

        public Travel(IZones zones)
        {
            _zones = zones;
        }

        public CustomerSummaries Compute(List<Tap> tapsList)
        {
            IEnumerable<IGrouping<int,Tap>> tapByCustomerId = tapsList.GroupBy(tap => tap.CustomerId);
            IEnumerable<CustomerSummary> customerSummaries = tapByCustomerId.Select(x => new CustomerSummary
            {
                CustomerId = x.Key,
                Trips = CreateTrips(x.ToList()).ToArray()
            });
            return new CustomerSummaries{Summaries = customerSummaries.ToArray()};
        }

        private IEnumerable<Trip> CreateTrips(List<Tap> taps)
        {
            var orderedTaps = taps.OrderBy(t => t.UnixTimeStamp).ToList();
            for (int i = 0; i < orderedTaps.Count; i+= 2)
            {
                Tap start = orderedTaps[i];
                Tap end = orderedTaps[i + 1];
                yield return new Trip
                {
                    StationStart = start.Station, 
                    StationEnd = end.Station,
                    ZoneFrom = _zones.From(start.Station),
                    ZoneTo = _zones.To(end.Station),
                    CostInCents = _zones.Cost(start.Station, end.Station),
                    StartedJourneyAt = start.UnixTimeStamp
                };
            }
        }
    }
}