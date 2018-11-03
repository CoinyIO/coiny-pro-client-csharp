using System;
using CoinyPro.Client.Models.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinyPro.Client.Models.Responses
{
    public class TradeMatchResponse : BaseResponse
    {
        public DateTimeOffset CreateDate { get; set; }
        public string OrderId { get; set; }

        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TradeMatchType TradeMatchType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Side Side { get; set; }
        public OrderResponse Order { get; set; }
    }


    public enum TradeMatchType
    {
        Undefined = 0,
        Maker,
        Taker
    }
}
