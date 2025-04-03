using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels;

namespace EasyTravel.Solution.Contracts.Contracts.Flights.Responses
{
    public class FlightOfferResponseDto
    {
        public List<FlightOfferDto> Data { get; set; }

        public FlightOfferDictionariesDto Dictionaries { get; set; }
    }
    public class FlightOfferDto
    {
        public string Type { get; set; }

        public string Source { get; set; }

        public bool InstantTicketingRequired { get; set; }

        public bool OneWay { get; set; }

        public string LastTicketingDate { get; set; }

        public int NumberOfBookableSeats { get; set; }

        public List<FlightOfferItineraryDto> Itineraries { get; set; }

        public FlightOfferPriceDto Price { get; set; }

        public FlightOfferPricingOptionsDto PricingOptions { get; set; }

        public List<string> ValidatingAirlineCodes { get; set; }

        public List<FlightOfferTravelerPricingDto> TravelerPricings { get; set; }
    }
    public class FlightOfferItineraryDto
    {
        public string Duration { get; set; }

        public List<FlightOfferSegmentDto> Segments { get; set; }
    }
    public class FlightOfferSegmentDto
    {
        public FlightOfferDepartureArrivalDto Departure { get; set; }

        public FlightOfferDepartureArrivalDto Arrival { get; set; }

        public string CarrierCode { get; set; }

        public string Number { get; set; }

        public FlightOfferAircraftDto Aircraft { get; set; }

        public string Duration { get; set; }

        public int NumberOfStops { get; set; }

        public bool BlacklistedInEU { get; set; }
    }
    public class FlightOfferAircraftDto
    {
        public string Code { get; set; }
    }

    public class FlightOfferDepartureArrivalDto
    {
        public string IataCode { get; set; }

        public DateTime At { get; set; }
    }
    public class FlightOfferPriceDto
    {
        public string Currency { get; set; }

        public string Total { get; set; }

        public string Base { get; set; }

        public List<FlightOfferFeeDto> Fees { get; set; }

        public string GrandTotal { get; set; }
    }
    public class FlightOfferFeeDto
    {
        public string Amount { get; set; }

        public string Type { get; set; }
    }
    public class FlightOfferPricingOptionsDto
    {
        public List<string> FareType { get; set; }

        public bool IncludedCheckedBagsOnly { get; set; }
    }
    public class FlightOfferDictionariesDto
    {
        public Dictionary<string, FlightOfferLocationDto> Locations { get; set; }

        public Dictionary<string, string> Aircraft { get; set; }

        public Dictionary<string, string> Currencies { get; set; }

        public Dictionary<string, string> Carriers { get; set; }
    }
    public class FlightOfferLocationDto
    {
        public string CityCode { get; set; }

        public string CountryCode { get; set; }
    }
    public class FlightOfferTravelerPricingDto
    {
        public string TravelerId { get; set; }

        public string FareOption { get; set; }

        public string TravelerType { get; set; }

        public FlightOfferPriceDto Price { get; set; }

        public List<FlightOfferFareDetailsBySegmentDto> FareDetailsBySegment { get; set; }
    }
    public class FlightOfferFareDetailsBySegmentDto
    {
        public string SegmentId { get; set; }

        public string Cabin { get; set; }

        public string FareBasis { get; set; }

        public string Class { get; set; }

        public FlightOfferIncludedCheckedBagsDto IncludedCheckedBags { get; set; }
    }
    public class FlightOfferIncludedCheckedBagsDto
    {
        public int Quantity { get; set; }
    }
}
