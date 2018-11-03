namespace CoinyPro.Client.Models.Responses
{
    public class PriceResponse
    {
        public string TradeId { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public double Size { get; set; }
        public decimal Price { get; set; }
        public double Volume { get; set; }
        public CurrencyResponse Currency { get; set; }
    }
}
