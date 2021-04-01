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
                (Zone startZone, Zone endZone, int _) valueTuple = _zones.CheapestTripFrom(start.Station, end.Station);
                yield return new Trip
                {
                    StationStart = start.Station, 
                    StationEnd = end.Station,
                    ZoneFrom = valueTuple.startZone.Matricule,
                    ZoneTo = valueTuple.endZone.Matricule,
                    CostInCents = _zones.Cost(valueTuple.startZone, valueTuple.endZone),
                    StartedJourneyAt = start.UnixTimeStamp
                };
            }
        }
    }
}