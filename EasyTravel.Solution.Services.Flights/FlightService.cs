using System.Text.Json;
using EasyTravel.Solution.Contracts.Interfaces;
using EasyTravel.Solution.Contracts.Contracts.Flights.Requests;
using EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels;
using EasyTravel.Solution.Contracts.Contracts.Flights.Responses;
using EasyTravel.Solution.ThirdPartyConnections.Contracts;
using AutoMapper;

namespace EasyTravel.Solution.Services
{

    public class FlightService : IFlightService
    {
        private IAuthenticationService _authenticationService;
        private readonly IApiProxy _apiProxy;
        private readonly IMapper _mapper;


        public FlightService(IAuthenticationService authenticationService, IApiProxy apiProxy, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _apiProxy = apiProxy;
            _mapper = mapper;
        }

        public async Task<AmadeusFlightResponseDto> GetFlights(FlightRequestDto flightRequestDto)
        {
            try
            {
                var token = await _authenticationService.GetTokenAsync("ckUD88UAsGlU5o2J6EFT3zhnMFN0OfKa", "if5MXVly3Fp4Tqfx");
                var request = GetFlightSearchRequest(flightRequestDto);
                var jsonResponse = await _apiProxy.PostAsync("https://test.api.amadeus.com/v2/shopping/flight-offers", token.AccessToken, request);

                if (!string.IsNullOrWhiteSpace(jsonResponse))
                {
                    var deserializedReponse = JsonSerializer.Deserialize<AmadeusFlightResponseDto>(jsonResponse,
                                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return deserializedReponse;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<FlightDestinationFromOriginResponseDto> GetFlightsOffersFromOrigin(string origin, DateTime? departureDate, int? travelDays, decimal? maxPrice)
        {
            var token = await _authenticationService.GetTokenAsync("ckUD88UAsGlU5o2J6EFT3zhnMFN0OfKa", "if5MXVly3Fp4Tqfx");
            var departureDateStr = departureDate != null ? departureDate.Value.ToString("yyyy-MM-dd") : "";
            var travelDayStr = travelDays != null ? travelDays.Value.ToString() : "";
            var maxPriceStr = maxPrice != null ? maxPrice.Value.ToString() : "";

            var queryParams = new Dictionary<string, string>
            {
                { "origin", origin },
                { "departureDate", departureDateStr },
                { "duration", travelDayStr},
                { "maxPrice", maxPriceStr },
             };

            string apiUrl = "https://test.api.amadeus.com/v1/shopping/flight-destinations";

            var jsonResponse = await _apiProxy.GetAsync(apiUrl, token.AccessToken, queryParams);
            var result = new FlightDestinationFromOriginResponseDto { };
            try
            {
                if (!string.IsNullOrWhiteSpace(jsonResponse))
                {
                    var deserializedReponse = JsonSerializer.Deserialize<AmadeusFlightDestinationFromOriginResponseDto>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (deserializedReponse != null)
                        result = _mapper.Map<FlightDestinationFromOriginResponseDto>(deserializedReponse);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        private List<FlightOffersFromOriginDto>? MapAmadeusFlightSestinationResponse(List<AmadeusFlightResponseDto>? flightOffers)
        {
            if (flightOffers == null || flightOffers.Count == 0)
                return null;
            var result = new List<FlightOffersFromOriginDto>();
            foreach (var flightOffer in flightOffers)
            {
                result.Add(new FlightOffersFromOriginDto
                {

                });
            }
            throw new NotImplementedException();
        }

        private static AmadeusFlightSearchRequestDto GetFlightSearchRequest(FlightRequestDto flightRequestDto)
        {
            return new AmadeusFlightSearchRequestDto
            {
                CurrencyCode = "USD",
                OriginDestinations = new List<OriginDestinationDto>
                        {
                            new OriginDestinationDto
                            {
                                Id = "1",
                                OriginLocationCode = flightRequestDto.DepartureStation,
                                DestinationLocationCode = flightRequestDto.ArrivalStation,
                                DepartureDateTimeRange = new DepartureDateTimeRangeDto
                                {
                                    Date = flightRequestDto.DepartureDate.ToString("yyyy-MM-dd"),  // replace with actual departure date
                                    //Time = "10:00:00"
                                }
                            },
                            new OriginDestinationDto
                            {
                                Id = "2",
                                OriginLocationCode = flightRequestDto.ArrivalStation,
                                DestinationLocationCode = flightRequestDto.DepartureStation,
                                DepartureDateTimeRange = new DepartureDateTimeRangeDto
                                {
                                    Date = flightRequestDto.ReturnDate.ToString("yyyy-MM-dd"),  // replace with actual return date
                                   // Time = "17:00:00"
                                }
                            }
                        },
                Travelers = new List<TravelerDto>
                        {
                            new TravelerDto
                            {
                                Id = "1",
                                TravelerType = "ADULT"
                            },
                            new TravelerDto
                            {
                                Id = "2",
                                TravelerType = "CHILD"
                            }
                        },
                Sources = new List<string> { "GDS" },
                SearchCriteria = new SearchCriteriaDto
                {
                    MaxFlightOffers = 2,
                    FlightFilters = new FlightFiltersDto
                    {
                        CabinRestrictions = new List<CabinRestrictionDto>
                                {
                                    new CabinRestrictionDto
                                    {
                                        Cabin = "BUSINESS",
                                        Coverage = "MOST_SEGMENTS",
                                        OriginDestinationIds = new List<string> { "1" }
                                    }
                                }
                    }
                }
            };


        }
    }
}
