using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoinyPro.Client.Extensions;
using CoinyPro.Client.Interfaces;
using CoinyPro.Client.Models.Requests;
using CoinyPro.Client.Models.Responses;
using Newtonsoft.Json;

namespace CoinyPro.Client.Services
{
    public class OrderService : BaseService<OrderRequest, OrderResponse>, IOrderService
    {
        //the endpoint will be base_url/orders
        public OrderService(HttpClient client) : base("orders", client)
        {
        }


        public async Task<BaseResponseWrapper<OrderResponse>> CreateOrderAsync(OrderRequest request)
        {
            return await CreateAsync(request);
        }

        public async Task<PaginatedResponseWrapper<OrderResponse>> GetOrdersAsync(string pair = null, List<OrderStatus> statuses = null, int page = 0, int size = 100)
        {

            var queryStrings = new List<string>();

            if (statuses != null && statuses.Count > 0)
            {
                statuses.ForEach(t =>
                {
                    queryStrings.Add($"status={t}");
                });
            }

            queryStrings.Add($"page={page}");
            queryStrings.Add($"size={size}");
            if (!string.IsNullOrEmpty(pair))
            {
                queryStrings.Add($"pair={pair}");
            }

            var endPoint = $"{EndPoint}?{string.Join("&", queryStrings)}";

            return await Client.GetItemAsync<PaginatedResponseWrapper<OrderResponse>>(endPoint);
        }

        public async Task<HttpResponseMessage> CancelOrdersAsync(List<string> orderIds)
        {
            var data = JsonConvert.SerializeObject(orderIds);
            return await Client.DeleteItemAsync(EndPoint, data);
        }
    }



}
