namespace BNPKata
{
    public interface IZones
    {
        (Zone, Zone, int pricing) CheapestTripFrom(string startStation, string endStation);
    }
}