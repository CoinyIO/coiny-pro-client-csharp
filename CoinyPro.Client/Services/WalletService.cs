using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinyPro.Client.Extensions;
using CoinyPro.Client.Interfaces;
using CoinyPro.Client.Models.Responses;

namespace CoinyPro.Client.Services
{
    public class WalletService : BaseService<object, WalletResponse>, IWalletService
    {
        public WalletService(HttpClient client) : base("wallets", client)
        {
        }

        public async Task<BaseResponseWrapper<List<WalletResponse>>> GetWalletsAsync()
        {
            var endPoint = $"{EndPoint}";
            return await Client.GetItemAsync<BaseResponseWrapper<List<WalletResponse>>>(endPoint);
        }
    }
}
