namespace EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class AmadeusFlightSearchRequestDto
    {
        [JsonPropertyName("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("originDestinations")]
        public List<OriginDestinationDto> OriginDestinations { get; set; }

        [JsonPropertyName("travelers")]
        public List<TravelerDto> Travelers { get; set; }

        [JsonPropertyName("sources")]
        public List<string> Sources { get; set; }

        [JsonPropertyName("searchCriteria")]
        public SearchCriteriaDto SearchCriteria { get; set; }
    }

    public class OriginDestinationDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("originLocationCode")]
        public string OriginLocationCode { get; set; }

        [JsonPropertyName("destinationLocationCode")]
        public string DestinationLocationCode { get; set; }

        [JsonPropertyName("departureDateTimeRange")]
        public DepartureDateTimeRangeDto DepartureDateTimeRange { get; set; }
    }

    public class DepartureDateTimeRangeDto
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }
    }

    public class TravelerDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("travelerType")]
        public string TravelerType { get; set; }
    }

    public class SearchCriteriaDto
    {
        [JsonPropertyName("maxFlightOffers")]
        public int MaxFlightOffers { get; set; }

        [JsonPropertyName("flightFilters")]
        public FlightFiltersDto FlightFilters { get; set; }
    }

    public class FlightFiltersDto
    {
        [JsonPropertyName("cabinRestrictions")]
        public List<CabinRestrictionDto> CabinRestrictions { get; set; }
    }

    public class CabinRestrictionDto
    {
        [JsonPropertyName("cabin")]
        public string Cabin { get; set; }

        [JsonPropertyName("coverage")]
        public string Coverage { get; set; }

        [JsonPropertyName("originDestinationIds")]
        public List<string> OriginDestinationIds { get; set; }
    }

}
