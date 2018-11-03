using System.Collections.Generic;
using System.Threading.Tasks;
using CoinyPro.Client.Models.Requests;
using CoinyPro.Client.Models.Responses;

namespace CoinyPro.Client.Interfaces
{
    public interface ITradePairService
    {
        /// <summary>
        /// Gets trade pairs for specified currencies.
        /// </summary>
        /// <param name="currency">currency i.e btc</param>
        /// <returns></returns>
        Task<BaseResponseWrapper<List<TradePairResponse>>> GetTradePairsAsync(string currency = null);

        /// <summary>
        /// gets the candles for specified pair within specified interval.
        /// </summary>
        /// <param name="pair">pair i.e btc-try</param>
        /// <param name="interval">interval</param>
        /// <returns></returns>
        Task<BaseResponseWrapper<List<CandleResponse>>> GetCandlesAsync(string pair,
            CandleTimeInterval interval);

        /// <summary>
        /// Gets all the tickers in Coiny Pro
        /// </summary>
        /// <returns></returns>
        Task<BaseResponseWrapper<List<StatsResponse>>> GetTickerAsync();

        /// <summary>
        /// Gets the ticker for specified pair
        /// </summary>
        /// <param name="pair">pair i.e btc-try</param>
        /// <returns></returns>
        Task<BaseResponseWrapper<StatsResponse>> GetStatsAsync(string pair);

        /// <summary>
        /// Gets the order book of specified pair
        /// </summary>
        /// <param name="pair">pair i.e btc-try</param>
        /// <returns></returns>
        Task<BaseResponseWrapper<OrderBookResponse>> GetOrderBookAsync(string pair);
    }
}
