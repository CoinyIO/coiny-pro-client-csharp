using System.Collections.Generic;
using System.Threading.Tasks;
using CoinyPro.Client.Models.Responses;

namespace CoinyPro.Client.Interfaces
{

    public interface IWalletService
    {
        /// <summary>
        /// Gets the wallets of user.
        /// </summary>
        /// <returns></returns>
        Task<BaseResponseWrapper<List<WalletResponse>>> GetWalletsAsync();
    }
}
