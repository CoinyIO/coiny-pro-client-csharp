using System;
using System.Net.Http;
using CoinyPro.Client.Interfaces;
using CoinyPro.Client.Network;
using CoinyPro.Client.Services;

namespace CoinyPro.Client
{
    public class CoinyProClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        /// <param name="isDevelopment"></param>
        public CoinyProClient(string appId, string appKey, bool isDevelopment = true)
        {
            if (string.IsNullOrEmpty(appId)) throw new ArgumentNullException(nameof(appId));
            if (string.IsNullOrEmpty(appKey)) throw new ArgumentNullException(nameof(appKey));

            var client = HttpClientFactory.Create(new ClientHandler(appId, appKey));

            client.BaseAddress = isDevelopment ? new Uri("https://api-coiny-pro-dev.azurewebsites.net/") : new Uri("https://api-pro.coiny.io/");

            WalletService = new WalletService(client);
            OrderService = new OrderService(client);
            TradePairService = new TradePairService(client);

        }

        public IWalletService WalletService { get; }
        public IOrderService OrderService { get; }
        public ITradePairService TradePairService { get; }
    }
}
