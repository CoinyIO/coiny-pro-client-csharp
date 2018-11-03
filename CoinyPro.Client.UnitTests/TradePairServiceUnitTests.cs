using System;
using System.Threading.Tasks;
using CoinyPro.Client.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CoinyPro.Client.UnitTests
{
    [TestClass]
    public class TradePairServiceUnitTests : BaseTest
    {
        [TestMethod]
        public async Task Get_All_TradePairs_Success()
        {
            var response = await Client.TradePairService.GetTradePairsAsync();

            Console.WriteLine($"Trade Pairs Count:{response.Data.Count}");
            Assert.AreNotEqual(0, response.Data.Count);
        }

        [TestMethod]
        public async Task Get_All_Tickers_Success()
        {
            var response = await Client.TradePairService.GetTickerAsync();

            Console.WriteLine($"Tickers Count:{response.Data.Count}");
            Assert.AreNotEqual(0, response.Data.Count);
        }

        [TestMethod]
        public async Task Get_Stats_Success()
        {
            var response = await Client.TradePairService.GetStatsAsync("btc-try");

            Console.WriteLine($"BTC-TRY : {JsonConvert.SerializeObject(response.Data)}");
            Assert.AreNotEqual(null, response.Data);
        }

        [TestMethod]
        public async Task Get_OrderBook_Success()
        {
            var response = await Client.TradePairService.GetOrderBookAsync("btc-try");

            Console.WriteLine($"BTC-TRY : {JsonConvert.SerializeObject(response.Data)}");
            Assert.AreNotEqual(null, response.Data);
        }
        [TestMethod]
        public async Task Get_Candles_Success()
        {
            var response = await Client.TradePairService.GetCandlesAsync("btc-try", CandleTimeInterval.Day);

            Console.WriteLine($"BTC-TRY : {JsonConvert.SerializeObject(response.Data)}");
            Assert.AreNotEqual(null, response.Data);
        }
    }
}
