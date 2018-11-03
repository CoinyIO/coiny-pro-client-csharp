using System;

namespace CoinyPro.Client.Models.Requests
{
    public interface IBaseRequest<TKey>
    {
        TKey Id { get; set; }
    }

    public abstract class BaseRequest<TKey> : IBaseRequest<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }

    public class BaseRequest : BaseRequest<string>
    {

    }
}
