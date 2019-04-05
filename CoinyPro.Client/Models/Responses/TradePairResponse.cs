namespace CoinyPro.Client.Models.Responses
{
    public class TradePairResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double BaseMinSize { get; set; }
        public double BaseMaxSize { get; set; }
        public double QuoteIncrement { get; set; }
        public CurrencyResponse BaseCurrency { get; set; }
        public CurrencyResponse QuoteCurrency { get; set; }
    }
}
