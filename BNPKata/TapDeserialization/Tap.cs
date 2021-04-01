namespace BNPKata
{
    public record Tap
    {
        public int UnixTimeStamp { get; init; }
        public int CustomerId { get; init; }
        public string Station { get; init; }
    }
}