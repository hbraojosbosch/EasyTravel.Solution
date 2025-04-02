using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EasyTravel.Solution.Contracts.Interfaces;
using EasyTravel.Solution.Contracts.Contracts.Authentication;
using System.Text.Json;

namespace EasyTravel.Solution.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<AuthenticationResponseDto?> GetTokenAsync(string apiKey, string apiSecret)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://test.api.amadeus.com/v1/security/oauth2/token");
            request.Content = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("client_id", apiKey),
            new KeyValuePair<string, string>("client_secret", apiSecret)
            });
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            AuthenticationResponseDto authReponse = null;
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode) 
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(jsonResponse))
                {
                    authReponse = JsonSerializer.Deserialize<AuthenticationResponseDto>(jsonResponse,
                                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            }


            return authReponse;
        }
    }
}
