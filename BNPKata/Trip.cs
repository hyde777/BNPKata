namespace BNPKata
{
    public class Trip
    {
        public string StationStart { get; init; }
        public string StationEnd { get; init; }
        public int StartedJourneyAt { get; init; }
        public int CostInCents { get; init; }
        public int ZoneFrom { get; init; }
        public int ZoneTo { get; init; }

        public static Trip Create(Tap start, Tap end, IZones zones)
        {
            (Zone startZone, Zone endZone, int pricing) trip = zones.CheapestTripFrom(start.Station, end.Station);
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