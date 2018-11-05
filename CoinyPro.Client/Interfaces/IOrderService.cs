using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinyPro.Client.Models.Requests;
using CoinyPro.Client.Models.Responses;

namespace CoinyPro.Client.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Creates order with specified order request.
        /// </summary>
        /// <param name="request">order request object</param>
        /// <returns></returns>
        Task<BaseResponseWrapper<OrderResponse>> CreateOrderAsync(OrderRequest request);
        /// <summary>
        /// Gets user orders
        /// </summary>
        /// <param name="pair">if specified, related pair orders will be returned. i.e btc-try</param>
        /// <param name="statuses">if specified, orders with specified status will be returned.</param>
        /// <param name="page">page</param>
        /// <param name="size">number of orders in a row</param>
        /// <returns>orders with paginatedwrapper</returns>
        Task<PaginatedResponseWrapper<OrderResponse>> GetOrdersAsync(string pair = null, List<OrderStatus> statuses = null, int page = 0,
            int size = 100);

        /// <summary>
        /// Cancels the specified orders.
        /// </summary>
        /// <param name="orderIds">list of order ids</param>
        /// <returns>200 or 204 will be returned.</returns>
        Task<HttpResponseMessage> CancelOrdersAsync(List<string> orderIds);

        /// <summary>
        /// Get User Specific Order
        /// </summary>
        /// <param name="orderId">Id of specific order</param>
        /// <returns></returns>
        Task<BaseResponseWrapper<OrderResponse>> GetOrderAsync(string orderId);
    }
}
