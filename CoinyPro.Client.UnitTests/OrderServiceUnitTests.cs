using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CoinyPro.Client.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CoinyPro.Client.UnitTests
{

    [TestClass]
    public class OrderServiceUnitTests : BaseTest
    {
        [TestMethod]
        public async Task Get_All_Orders_Success()
        {
            var orders = await Client.OrderService.GetOrdersAsync();
            Assert.AreNotSame(0, orders.TotalItemCount);
        }

        [TestMethod]
        public async Task Get_Open_Orders_Success()
        {
            var orders = await Client.OrderService.GetOrdersAsync(null, new List<OrderStatus>() { OrderStatus.Open });

            foreach (var order in orders.Data)
            {
                Assert.AreEqual(OrderStatus.Open, order.Status);
            }
        }

        [TestMethod]
        public async Task Get_Completed_Filled_Cancelled_Orders_Success()
        {
            var orders = await Client.OrderService.GetOrdersAsync(null, new List<OrderStatus>() { OrderStatus.Completed, OrderStatus.Filled, OrderStatus.Cancelled });

            foreach (var order in orders.Data)
            {
                Assert.IsTrue(order.Status == OrderStatus.Completed || order.Status == OrderStatus.Filled || order.Status == OrderStatus.Cancelled, JsonConvert.SerializeObject(order));
            }
        }

        [TestMethod]
        public async Task Get_BTC_TRY_Orders_Success()
        {
            var orders = await Client.OrderService.GetOrdersAsync("btc-try");

            Console.WriteLine("Orders Count:" + orders.TotalItemCount);
            foreach (var order in orders.Data)
            {
                Assert.AreEqual("btc-try", order.Pair.Name.ToLowerInvariant());
            }
        }

        [TestMethod]
        public async Task Get_Invalid_Pair_Orders_Failed()
        {
            var orders = await Client.OrderService.GetOrdersAsync("xxx-yyy");
            Console.WriteLine(JsonConvert.SerializeObject(orders));
            Assert.AreEqual("Error", orders.Status);
        }

        [TestMethod]
        public async Task Create_Limit_Buy_Order_Success()
        {
            var order = new OrderRequest() { Pair = "btc-try", AllowTaker = false, Amount = 1, OrderType = OrderType.Limit, Quantity = 0.001m, Side = Side.Buy };
            var response = await Client.OrderService.CreateOrderAsync(order);
            Assert.AreEqual(OrderStatus.Pending, response.Data.Status);
            Assert.AreEqual(Side.Buy, response.Data.Side);
            Assert.AreEqual(OrderType.Limit, response.Data.OrderType);
        }

        [TestMethod]
        public async Task Create_Limit_Sell_Order_Success()
        {
            var order = new OrderRequest() { Pair = "btc-try", AllowTaker = false, Amount = 100000, OrderType = OrderType.Limit, Quantity = 0.001m, Side = Side.Sell };
            var response = await Client.OrderService.CreateOrderAsync(order);
            Assert.AreEqual(OrderStatus.Pending, response.Data.Status);
            Assert.AreEqual(Side.Sell, response.Data.Side);
            Assert.AreEqual(OrderType.Limit, response.Data.OrderType);
        }

        [TestMethod]
        public async Task Create_Limit_Buy_AllowTaker_Order_Fail()
        {
            var order = new OrderRequest() { Pair = "btc-try", AllowTaker = false, Amount = 100000, OrderType = OrderType.Limit, Quantity = 0.001m, Side = Side.Buy };
            var response = await Client.OrderService.CreateOrderAsync(order);
            Assert.AreEqual("Error", response.Status);
        }

        [TestMethod]
        public async Task Cancel_an_Order_Success()
        {
            var statusList = new List<OrderStatus> { OrderStatus.Pending, OrderStatus.Open };
            var order = await Client.OrderService.GetOrdersAsync("btc-try", statusList);
            var itemCount = order.TotalItemCount;
            var response = await Client.OrderService.CancelOrdersAsync(new List<string>() { order.Data.First().Id });
            var newOrders = await Client.OrderService.GetOrdersAsync("btc-try", statusList);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent);
            Console.WriteLine($"Before:{itemCount} After:{newOrders.TotalItemCount}");
            Assert.AreNotEqual(itemCount, newOrders.TotalItemCount);

        }
    }
}
