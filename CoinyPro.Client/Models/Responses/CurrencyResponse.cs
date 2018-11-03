namespace CoinyPro.Client.Models.Responses
{
    public class CurrencyResponse : BaseResponse
    {
        /// <summary>
        /// Name of Currency, ie. Dollar
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Shortname of Currency, ie. USD
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Symbol of Currency, ie. $
        /// </summary>
        public string Symbol { get; set; }
    }
}
