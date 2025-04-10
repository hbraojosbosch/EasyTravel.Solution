using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels;
using EasyTravel.Solution.Contracts.Interfaces;
using EasyTravel.Solution.ThirdPartyConnections.Contracts;

namespace EasyTravel.Solution.Services
{
    public class AirportsAndCityService : IAirportsAndCityService
    {
        private IAuthenticationService _authenticationService;
        private readonly HttpClient _httpClient;
        private readonly ICacheService _cacheService;

        public AirportsAndCityService(HttpClient httpClient, IAuthenticationService authenticationService,
                                      ICacheService cacheService)
        {
            _httpClient = httpClient;
            _authenticationService = authenticationService;
            _cacheService = cacheService;
        }

        public async Task<List<AmadeusLocationInfoResponseDto>> GetLocationsAsync()
        {
            List<AmadeusLocationInfoResponseDto> allLocations = new();

            var cachedValues = await _cacheService.GetValueAsync("AmadeusLocations");
            if (!string.IsNullOrWhiteSpace(cachedValues))
            {
                allLocations = JsonSerializer.Deserialize<List<AmadeusLocationInfoResponseDto>>(cachedValues);
            }

            return allLocations;
        }

        public async Task SetLocationToMemoryCacheAsync()
        {
            var token = await _authenticationService.GetTokenAsync("ckUD88UAsGlU5o2J6EFT3zhnMFN0OfKa", "if5MXVly3Fp4Tqfx");
            if (token != null)
            {
                List<AmadeusLocationInfoResponseDto> allLocations = new();
                foreach (char letter in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
                {
                    int limit = 100;
                    int offset = 0;
                    bool moreData = true;
                    while (moreData)
                    {
                        var locations = await GetLocations(letter.ToString(), token.AccessToken, limit, offset);
                        if (locations?.Data?.Any() != true)
                        {
                            moreData = false;
                            break;
                        }
                        allLocations.Add(locations);

                        offset += limit;
                        await Task.Delay(100); // Avoid rate limits
                    }
                }
                var serializedLocations = JsonSerializer.Serialize(allLocations);
                await _cacheService.SetValueAsync("AmadeusLocations", serializedLocations);
            }
        }

        private async Task<AmadeusLocationInfoResponseDto> GetLocations(string keyword, string token, int limit, int offset)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string url1 = $"https://test.api.amadeus.com/v1/reference-data/locations?subType=AIRPORT&keyword={keyword}&page[limit]={limit}&page[offset]={offset}";
            var response = await _httpClient.GetAsync(url1);
            if (!response.IsSuccessStatusCode)
                return new AmadeusLocationInfoResponseDto();

            var responseBody = await response.Content.ReadAsStringAsync();
            var deserializedResponse = JsonSerializer.Deserialize<AmadeusLocationInfoResponseDto>(responseBody);

            return deserializedResponse ?? new AmadeusLocationInfoResponseDto { };
        }

        public Task<List<AmadeusLocationInfoResponseDto>> GetLocationsAsync(List<string> Cities, string token)
        {
            throw new NotImplementedException();
        }
    }
}
