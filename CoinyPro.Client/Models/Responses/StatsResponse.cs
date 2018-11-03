namespace CoinyPro.Client.Models.Responses
{
    public class StatsResponse
    {
        public decimal OpenPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal Volume { get; set; }
        public decimal NowPrice { get; set; }
        public string Pair { get; set; }
        public string BaseSymbol { get; set; }
        public string QuoteSymbol { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
    }
}
