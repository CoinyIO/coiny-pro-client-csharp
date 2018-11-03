using System;

namespace CoinyPro.Client.Models.Responses
{
    public class CandleResponse
    {
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public DateTime Timestamp { get; set; }
        public double VolumePrice { get; set; }
        public double VolumeQuantity { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
    }
}
