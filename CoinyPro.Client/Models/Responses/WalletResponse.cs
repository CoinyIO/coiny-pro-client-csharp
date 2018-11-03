using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinyPro.Client.Models.Responses
{
    public class WalletResponse : BaseResponse
    {
        public decimal Balance { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public WalletType Type { get; set; }
        public string Name { get; set; }
        public CurrencyResponse Currency { get; set; }
        public decimal BlockedBalance { get; set; }
        public List<WalletAddressResponse> Addresses { get; set; }
    }


    public enum WalletType
    {
        Undefined = 0,
        Crypto = 1,
        Fiat = 2
    }
}
