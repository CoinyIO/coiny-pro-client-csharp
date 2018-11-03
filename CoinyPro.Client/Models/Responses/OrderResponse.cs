using System;
using System.Collections.Generic;
using CoinyPro.Client.Models.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinyPro.Client.Models.Responses
{
    public class OrderResponse : BaseResponse
    {
        public DateTimeOffset CreateDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus Status { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType OrderType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Side Side { get; set; }
        public decimal Quantity { get; set; }
        /// <summary>
        /// Amount related with From Currency
        /// </summary>
        public decimal Amount { get; set; }
        public decimal RemainingQuantity { get; set; }
        public decimal RemainingAmount { get; set; }
        public string PairId { get; set; }
        public TradePairResponse Pair { get; set; }

        public string UserId { get; set; }


        public bool IsInstant { get; set; }
        public List<TransactionResponse> Transactions { get; set; }
    }
}
