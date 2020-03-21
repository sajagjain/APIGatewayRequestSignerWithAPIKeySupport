using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwsExecuteAPIExample
{
    class Program
    {
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly string _service;
        private readonly string _region;
        private readonly Uri _requestUri;
        private readonly string _json;
        private readonly string _x_api_key;

        public Program()
        {
            _accessKey = "<your_access_key>";
            _secretKey = "<your_secret_key>";
            _service = "execute-api";
            _region = "us-east-2";
            _requestUri = new Uri("your_api_gateway_endpoint");
            //Make sure to type your json with double quotes. Single quotes does not work while parsing the data
            _json = "{\"type\":\"dog\",\"price\":2008}";
            _x_api_key = "<api_key_value_if_configured>";
        }

        static void Main(string[] args)
        {
            new Program().TestSigner().GetAwaiter().GetResult();
            
        }

        public async Task TestSigner()
        {
            var signer = new AWS4RequestSigner(_accessKey, _secretKey);
            var content = new StringContent(_json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = _requestUri,
                Content = content
            };

            request = await signer.Sign(request, _service, _region,_x_api_key);

            var client = new HttpClient();
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
