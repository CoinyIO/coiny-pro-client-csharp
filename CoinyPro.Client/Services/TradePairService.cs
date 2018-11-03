using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinyPro.Client.Extensions;
using CoinyPro.Client.Interfaces;
using CoinyPro.Client.Models.Requests;
using CoinyPro.Client.Models.Responses;

namespace CoinyPro.Client.Services
{
    public class TradePairService : BaseService<object, TradeMatchResponse>, ITradePairService
    {
        public TradePairService(HttpClient client) : base("trade-pairs", client)
        {

        }
        public async Task<BaseResponseWrapper<List<TradePairResponse>>> GetTradePairsAsync(string currency = null)
        {
            var url = string.IsNullOrEmpty(currency) ? EndPoint : $"{EndPoint}?currency={currency}";
            var response = await Client.GetItemAsync<BaseResponseWrapper<List<TradePairResponse>>>(url);
            return response;
        }

        public async Task<BaseResponseWrapper<List<CandleResponse>>> GetCandlesAsync(string pair,
            CandleTimeInterval interval)
        {
            var response =
                await Client.GetItemAsync<BaseResponseWrapper<List<CandleResponse>>>(
                    $"{EndPoint}/{pair}/candles?interval={interval}");
            return response;
        }

        public async Task<BaseResponseWrapper<List<StatsResponse>>> GetTickerAsync()
        {
            var response =
                await Client.GetItemAsync<BaseResponseWrapper<List<StatsResponse>>>(
                    $"{EndPoint}/ticker");
            return response;
        }

        public async Task<BaseResponseWrapper<StatsResponse>> GetStatsAsync(string pair)
        {
            var response =
                await Client.GetItemAsync<BaseResponseWrapper<StatsResponse>>(
                    $"{EndPoint}/{pair}/stats");
            return response;
        }

        public async Task<BaseResponseWrapper<OrderBookResponse>> GetOrderBookAsync(string pair)
        {
            var response =
                await Client.GetItemAsync<BaseResponseWrapper<OrderBookResponse>>(
                    $"{EndPoint}/{pair}/book");
            return response;
        }
    }
}
