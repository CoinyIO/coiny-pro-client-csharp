namespace CoinyPro.Client.Models.Responses
{
    public class TradePairResponse
    {
        public string Name { get; set; }
        public CurrencyResponse BaseCurrency { get; set; }
        public CurrencyResponse QuoteCurrency { get; set; }
    }
}
