namespace BNPKata
{
    public class CustomerSummary
    {
        public int CustomerId { get; init; }
        public int TotalCostInCents { get; init; }
        public Trips[] Trips { get; init; }
    }
}