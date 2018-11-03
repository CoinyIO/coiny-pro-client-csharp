using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinyPro.Client.Extensions;
using CoinyPro.Client.Interfaces;
using CoinyPro.Client.Models.Responses;

namespace CoinyPro.Client.Services
{

    public abstract class BaseService<TRequest, TResponse> : IBaseService<TRequest, TResponse>
    {
        protected readonly string EndPoint;
        protected readonly HttpClient Client;

        protected BaseService(string endPoint, HttpClient client)
        {
            EndPoint = endPoint;
            Client = client;
        }

        public async Task<BaseResponseWrapper<TResponse>> CreateAsync(TRequest request)
        {
            var response = await Client.PostItemAsync<BaseResponseWrapper<TResponse>>(EndPoint, request);
            return response;
        }

        public async Task<BaseResponseWrapper<TResponse>> UpdateAsync(string id, TRequest request)
        {
            var response = await Client.PutItemAsync<BaseResponseWrapper<TResponse>>(EndPoint + "/" + id, request);
            return response;
        }

        public async Task DeleteAsync(string id)
        {
            await Client.DeleteItemAsync<BaseResponseWrapper<TResponse>>(EndPoint + "/" + id);
        }

        public async Task<BaseResponseWrapper<TResponse>> GetAsync(string id)
        {
            var response = await Client.GetItemAsync<BaseResponseWrapper<TResponse>>(EndPoint + "/" + id);
            return response;
        }

        public async Task<BaseResponseWrapper<List<TResponse>>> GetAsync()
        {
            var response = await Client.GetItemAsync<BaseResponseWrapper<List<TResponse>>>(EndPoint + "/");
            return response;
        }

        public async Task<PaginatedResponseWrapper<TResponse>> GetAsync<T>(int page = 0, int size = 40)
        {
            var response = await Client.GetItemAsync<PaginatedResponseWrapper<TResponse>>(EndPoint + $"?page={page}&size={size}");
            return response;
        }

    }
}
