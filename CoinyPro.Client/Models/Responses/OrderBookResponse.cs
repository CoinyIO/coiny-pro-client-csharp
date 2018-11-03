using System.Collections.Generic;

namespace CoinyPro.Client.Models.Responses
{

    public class OrderBookResponse
    {
        public int Sequence { get; set; }
        public List<string[]> Bids { get; set; }
        public List<string[]> Asks { get; set; }
    }
}
