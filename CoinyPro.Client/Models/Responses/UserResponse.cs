using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinyPro.Client.Models.Responses
{

    public class UserResponse : BaseResponse
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ImageUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public UserStatus Status { get; set; }
        public string VoucherId { get; set; }
    }


    public enum UserStatus
    {
        Rejected = -1,
        Unverified = 0,
        Processing,
        Verified
    }
}
