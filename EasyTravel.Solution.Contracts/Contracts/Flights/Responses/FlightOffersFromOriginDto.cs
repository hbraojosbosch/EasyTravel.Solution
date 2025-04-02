using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels;

namespace EasyTravel.Solution.Contracts.Contracts.Flights.Responses
{
    public class FlightOffersFromOriginDto
    {
        public string Type { get; set; }

        public string Source { get; set; }

        public bool InstantTicketingRequired { get; set; }

        public bool OneWay { get; set; }

        public string LastTicketingDate { get; set; }

        public int NumberOfBookableSeats { get; set; }

        public List<ItineraryDto> Itineraries { get; set; }

        public PriceDto Price { get; set; }

        public PricingOptionsDto PricingOptions { get; set; }

        public List<string> ValidatingAirlineCodes { get; set; }

        public List<TravelerPricingDto> TravelerPricings { get; set; }
    }

    public class PriceDto
    {
        public string Currency { get; set; }

        public string Total { get; set; }

        public string Base { get; set; }

        public List<FeeDto> Fees { get; set; }

    }

    public class FeeDto
    {
        public string Amount { get; set; }

        public string Type { get; set; }
    }

    public class ItineraryDto
    {
        public string Duration { get; set; }

        public List<SegmentDto> Segments { get; set; }
    }

    public class SegmentDto
    {
        public DepartureArrivalDto Departure { get; set; }

        public DepartureArrivalDto Arrival { get; set; }

        public string CarrierCode { get; set; }

        public string Number { get; set; }

        public AircraftDto Aircraft { get; set; }

        public string Duration { get; set; }

        public int NumberOfStops { get; set; }

        public bool BlacklistedInEU { get; set; }
    }

    public class DepartureArrivalDto
    {
        public string IataCode { get; set; }

        public DateTime At { get; set; }
    }
    public class AircraftDto
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public class PricingOptionsDto
    {
        public List<string> FareType { get; set; }

        public bool IncludedCheckedBagsOnly { get; set; }
    }
}
