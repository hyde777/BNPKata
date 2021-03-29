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
    }
}