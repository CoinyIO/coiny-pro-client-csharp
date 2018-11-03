using System.Collections.Generic;
using System.Threading.Tasks;
using CoinyPro.Client.Models.Responses;

namespace CoinyPro.Client.Interfaces
{
    public interface IBaseService<TRequest, TResponse>
    {
        Task<BaseResponseWrapper<TResponse>> CreateAsync(TRequest request);
        Task<BaseResponseWrapper<TResponse>> UpdateAsync(string id, TRequest request);
        Task<BaseResponseWrapper<TResponse>> GetAsync(string id);
        Task<BaseResponseWrapper<List<TResponse>>> GetAsync();
        Task<PaginatedResponseWrapper<TResponse>> GetAsync<T>(int page, int size);
    }
}
