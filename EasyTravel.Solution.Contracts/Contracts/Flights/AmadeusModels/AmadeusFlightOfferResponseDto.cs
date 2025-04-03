
namespace EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class AmadeusFlightOfferMetaDto
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }

    public class AmadeusDepartureArrivalDto
    {
        [JsonPropertyName("iataCode")]
        public string IataCode { get; set; }

        [JsonPropertyName("at")]
        public DateTime At { get; set; }
    }

    public class AmadeusAircraftDto
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public class OperatingDto
    {
        [JsonPropertyName("carrierCode")]
        public string CarrierCode { get; set; }
    }

    public class AmadeusSegmentDto
    {
        [JsonPropertyName("departure")]
        public AmadeusDepartureArrivalDto Departure { get; set; }

        [JsonPropertyName("arrival")]
        public AmadeusDepartureArrivalDto Arrival { get; set; }

        [JsonPropertyName("carrierCode")]
        public string CarrierCode { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("aircraft")]
        public AmadeusAircraftDto Aircraft { get; set; }

        [JsonPropertyName("operating")]
        public OperatingDto Operating { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("numberOfStops")]
        public int NumberOfStops { get; set; }

        [JsonPropertyName("blacklistedInEU")]
        public bool BlacklistedInEU { get; set; }
    }

    public class AmadeusItineraryDto
    {
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("segments")]
        public List<AmadeusSegmentDto> Segments { get; set; }
    }

    public class AmadeusFeeDto
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class AmadeusPriceDto
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("total")]
        public string Total { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("fees")]
        public List<AmadeusFeeDto> Fees { get; set; }

        [JsonPropertyName("grandTotal")]
        public string GrandTotal { get; set; }
    }

    public class AmadeusPricingOptionsDto
    {
        [JsonPropertyName("fareType")]
        public List<string> FareType { get; set; }

        [JsonPropertyName("includedCheckedBagsOnly")]
        public bool IncludedCheckedBagsOnly { get; set; }
    }

    public class AmadeusIncludedCheckedBagsDto
    {
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }

    public class AmadeusFareDetailsBySegmentDto
    {
        [JsonPropertyName("segmentId")]
        public string SegmentId { get; set; }

        [JsonPropertyName("cabin")]
        public string Cabin { get; set; }

        [JsonPropertyName("fareBasis")]
        public string FareBasis { get; set; }

        [JsonPropertyName("class")]
        public string Class { get; set; }

        [JsonPropertyName("includedCheckedBags")]
        public AmadeusIncludedCheckedBagsDto IncludedCheckedBags { get; set; }
    }

    public class AmadeusTravelerPricingDto
    {
        [JsonPropertyName("travelerId")]
        public string TravelerId { get; set; }

        [JsonPropertyName("fareOption")]
        public string FareOption { get; set; }

        [JsonPropertyName("travelerType")]
        public string TravelerType { get; set; }

        [JsonPropertyName("price")]
        public AmadeusPriceDto Price { get; set; }

        [JsonPropertyName("fareDetailsBySegment")]
        public List<AmadeusFareDetailsBySegmentDto> FareDetailsBySegment { get; set; }
    }

    public class AmadeusFlightOfferDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("instantTicketingRequired")]
        public bool InstantTicketingRequired { get; set; }

        [JsonPropertyName("nonHomogeneous")]
        public bool NonHomogeneous { get; set; }

        [JsonPropertyName("oneWay")]
        public bool OneWay { get; set; }

        [JsonPropertyName("lastTicketingDate")]
        public string LastTicketingDate { get; set; }

        [JsonPropertyName("numberOfBookableSeats")]
        public int NumberOfBookableSeats { get; set; }

        [JsonPropertyName("itineraries")]
        public List<AmadeusItineraryDto> Itineraries { get; set; }

        [JsonPropertyName("price")]
        public AmadeusPriceDto Price { get; set; }

        [JsonPropertyName("pricingOptions")]
        public AmadeusPricingOptionsDto PricingOptions { get; set; }

        [JsonPropertyName("validatingAirlineCodes")]
        public List<string> ValidatingAirlineCodes { get; set; }

        [JsonPropertyName("travelerPricings")]
        public List<AmadeusTravelerPricingDto> TravelerPricings { get; set; }
    }

    public class AmadeusLocationDto
    {
        public string CityCode { get; set; }

        public string CountryCode { get; set; }
    }

    public class AmadeusDictionariesDto
    {
        [JsonPropertyName("locations")]
        public Dictionary<string, AmadeusLocationDto> Locations { get; set; }

        [JsonPropertyName("aircraft")]
        public Dictionary<string, string> Aircraft { get; set; }

        [JsonPropertyName("currencies")]
        public Dictionary<string, string> Currencies { get; set; }

        [JsonPropertyName("carriers")]
        public Dictionary<string, string> Carriers { get; set; }
    }

    public class AmadeusFlightOfferResponseDto
    {
        [JsonPropertyName("meta")]
        public AmadeusFlightOfferMetaDto Meta { get; set; }

        [JsonPropertyName("data")]
        public List<AmadeusFlightOfferDto> Data { get; set; }

        [JsonPropertyName("dictionaries")]
        public AmadeusDictionariesDto Dictionaries { get; set; }
    }

}
