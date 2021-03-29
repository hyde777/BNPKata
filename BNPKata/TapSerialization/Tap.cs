namespace BNPKata
{
    public record Tap
    {
        public string UnixTimeStamp { get; init; }
        public string CustomerId { get; init; }
        public string Station { get; init; }
    }
}