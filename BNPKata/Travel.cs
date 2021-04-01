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
            IEnumerable<CustomerSummary> customerSummaries = tapByCustomerId.Select(x =>
            {
                var trips = CreateTrips(x.ToList()).ToList();
                return new CustomerSummary
                {
                    CustomerId = x.Key,
                    TotalCostInCents = trips.Select(t => t.CostInCents).Sum(),
                    Trips = trips.ToArray()
                };
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
                yield return CreateTrip(start, end);
            }
        }

        private Trip CreateTrip(Tap start, Tap end)
        {
            (Zone startZone, Zone endZone, int pricing) trip = _zones.CheapestTripFrom(start.Station, end.Station);
            return new Trip
            {
                StationStart = start.Station,
                StationEnd = end.Station,
                ZoneFrom = trip.startZone.Matricule,
                ZoneTo = trip.endZone.Matricule,
                CostInCents = trip.pricing,
                StartedJourneyAt = start.UnixTimeStamp
            };
        }
    }
}