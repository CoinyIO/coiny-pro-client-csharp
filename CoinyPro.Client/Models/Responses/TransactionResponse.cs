using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinyPro.Client.Models.Responses
{
    public class TransactionResponse : BaseResponse
    {
        public DateTimeOffset CreateDate { get; set; }
        public string WalletId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionStatus Status { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType Type { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string ExternalId { get; set; }
        public int Confirmations { get; set; }
        public CurrencyResponse Currency { get; set; }
        public decimal PreBalance { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal Value { get; set; }
        public CurrencyResponse TradeCurrency { get; set; }
        public decimal TradeValue { get; set; }
        public string PaymentMethodId { get; set; }
    }

    public enum TransactionStatus
    {
        Rejected = -2,
        Failed = -1,
        Undefined = 0,
        Pending,
        Confirmed,
        Processing,
        Completed
    }

    public enum TransactionType
    {
        Undefined = 0,
        Buy,
        Sell,
        FiatDeposit,
        FiatWithdraw,
        CryptoDeposit,
        CryptoWithdraw,
        Trade,
        CryptoFee,
        MakerFee,
        TakerFee,
        FiatWithdrawFee
    }
}
