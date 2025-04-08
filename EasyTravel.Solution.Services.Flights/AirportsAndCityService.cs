using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IApiProxy _apiProxy;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        private readonly ICacheService _cacheService;

        public AirportsAndCityService(HttpClient httpClient, IAuthenticationService authenticationService,
                                      IApiProxy apiProxy, IMapper mapper, ICacheService cacheService)
        {
            _httpClient = httpClient;
            _authenticationService = authenticationService;
            _apiProxy = apiProxy;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<List<AmadeusLocationInfoResponseDto>> GetLocationsAsync()
        {
            List<AmadeusLocationInfoResponseDto> allLocations = new();
            var token = await _authenticationService.GetTokenAsync("ckUD88UAsGlU5o2J6EFT3zhnMFN0OfKa", "if5MXVly3Fp4Tqfx");
            foreach (char letter in "AB"/*CDEFGHIJKLMNOPQRSTUVWXYZ"*/)
            {
                Console.WriteLine($"Fetching locations for: {letter}");
                var locations = await GetLocations(letter.ToString(), token.AccessToken);
                allLocations.Add(locations);
                await Task.Delay(1000); // Avoid rate limits
            }

            var serializedLocations = JsonSerializer.Serialize(allLocations);
            await _cacheService.SetValueAsync("AmadeusLocations", serializedLocations);
            var cachedValues = await _cacheService.GetValueAsync("AmadeusLocations");
            return allLocations;
        }

        public async Task<AmadeusLocationInfoResponseDto> GetLocations(string keyword, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string url = $"https://test.api.amadeus.com/v1/reference-data/locations?subType=CITY,AIRPORT&keyword={keyword}";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) 
                return new AmadeusLocationInfoResponseDto();

            var responseBody = await response.Content.ReadAsStringAsync();
            var deserializedResponse = JsonSerializer.Deserialize<AmadeusLocationInfoResponseDto>(responseBody);

            return deserializedResponse ?? new AmadeusLocationInfoResponseDto { };
        }
    }
}
