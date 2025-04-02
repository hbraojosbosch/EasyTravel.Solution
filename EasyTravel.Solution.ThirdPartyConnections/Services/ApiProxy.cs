using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.WebUtilities;
using EasyTravel.Solution.ThirdPartyConnections.Contracts;

namespace EasyTravel.Solution.ThirdPartyConnections.Services
{
    public class ApiProxy : IApiProxy
    {
        private readonly HttpClient _httpClient;
        protected readonly ILogger<ApiProxy> _logger;

        public ApiProxy(HttpClient httpClient, ILogger<ApiProxy> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<string> PostAsync(string url, string accessToken, object content)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Headers.Add("Authorization", "Bearer " + accessToken);
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(content));
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(jsonResponse))
                {


                    return jsonResponse;
                }
            }
            return string.Empty;
        }

        public async Task<string> GetAsync(string url, string accessToken, Dictionary<string, string> content)
        {
            if (content == null)
                return string.Empty;

            var requestUrl = QueryHelpers.AddQueryString(url, content);
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            requestMessage.Headers.Add("Authorization", "Bearer " + accessToken);

            var response = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(jsonResponse))
                {
                    return jsonResponse;
                }
            }
            return string.Empty;
        }
    }
}
