using System.Net.Http;
using System.Threading.Tasks;
using Serilog.Sinks.Http;

namespace Serilog.Sink
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient httpClient;

        public CustomHttpClient()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", "secret-api-key");
        }

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };

            return httpClient.SendAsync(message);
        }

        public void Dispose() => httpClient?.Dispose();
    }
}
