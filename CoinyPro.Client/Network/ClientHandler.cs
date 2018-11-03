using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CoinyPro.Client.Network
{
    internal class ClientHandler : DelegatingHandler
    {
        private readonly string _appId;
        private readonly string _secretKey;

        public ClientHandler(string appId, string secretKey)
        {
            _appId = appId;
            _secretKey = secretKey;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestContentBase64String = string.Empty;

            var requestUri = HttpUtility.UrlEncode(request.RequestUri.AbsoluteUri.ToLower());

            var requestHttpMethod = request.Method.Method;

            //Calculate UNIX time
            var epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
            var timeSpan = DateTime.UtcNow - epochStart;
            var requestTimeStamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();

            //create random nonce for each request
            var nonce = Guid.NewGuid().ToString();

            //Checking if the request contains body, usually will be null wiht HTTP GET and DELETE
            if (request.Content != null)
            {
                byte[] content = await request.Content.ReadAsByteArrayAsync();
                MD5 md5 = MD5.Create();
                //Hashing the request body, any change in request body will result in different hash, we'll incure message integrity
                byte[] requestContentHash = md5.ComputeHash(content);
                requestContentBase64String = Convert.ToBase64String(requestContentHash);
            }

            //Creating the raw signature string
            var signatureRawData = $"{_appId}:{requestHttpMethod}:{requestUri}:{requestTimeStamp}:{nonce}:{requestContentBase64String}";

            var secretKeyByteArray = Convert.FromBase64String(_secretKey);

            var signature = Encoding.UTF8.GetBytes(signatureRawData);

            using (var hmac = new HMACSHA256(secretKeyByteArray))
            {
                var signatureBytes = hmac.ComputeHash(signature);
                var requestSignatureBase64String = Convert.ToBase64String(signatureBytes);
                request.Headers.Add("COINYPRO-ACCESS-KEY", _appId);
                request.Headers.Add("COINYPRO-ACCESS-SIGN", requestSignatureBase64String);
                request.Headers.Add("COINYPRO-ACCESS-TIMESTAMP", requestTimeStamp);
                request.Headers.Add("COINYPRO-ACCESS-NONCE", nonce);
            }

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}
