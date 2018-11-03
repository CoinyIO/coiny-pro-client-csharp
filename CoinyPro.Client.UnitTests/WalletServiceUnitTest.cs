using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoinyPro.Client.UnitTests
{
    [TestClass]
    public class WalletServiceUnitTest : BaseTest
    {
        [TestMethod]
        public async Task Get_Wallets_Success()
        {
            var response = await Client.WalletService.GetWalletsAsync();

            Console.WriteLine($"Wallet Count:{response.Data.Count}");
            Assert.AreNotSame(0, response.Data.Count);
        }
    }
}
