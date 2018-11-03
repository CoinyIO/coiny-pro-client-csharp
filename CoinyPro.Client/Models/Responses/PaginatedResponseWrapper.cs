using System.Collections.Generic;

namespace CoinyPro.Client.Models.Responses
{
    public class PaginatedResponseWrapper<T>
    {
        public List<T> Data { get; set; }
        public int TotalItemCount { get; set; }
        public int CurrentPage { get; set; }
        public int Size { get; set; }
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
        public string Status { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
        public int? ErrorCode { get; set; }
        public List<Error> Errors { get; set; }


    }

    public class BaseResponseWrapper<T>
    {
        public string Status { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }

        public int? ErrorCode { get; set; }
        public T Data { get; set; }

        public List<Error> Errors { get; set; }

    }

    public class Error
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
    }
}
