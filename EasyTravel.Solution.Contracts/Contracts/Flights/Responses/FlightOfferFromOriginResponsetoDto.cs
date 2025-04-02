using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Solution.Contracts.Contracts.Flights.Responses
{
    public class FlightOfferResponsetoDto
    {
        public List<FlightOfferData> Data { get; set; }
        public FlightDictionaries Dictionaries { get; set; }
        public FlightMeta Meta { get; set; }
    }

    public class FlightOfferData
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public FlightLocation Origin { get; set; }
        public FlightLocation Destination { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public FlightPrice Price { get; set; }
        public Airline Airline { get; set; }
        public FlightLinks Links { get; set; }
    }

    public class FlightLocation
    {
        public string IataCode { get; set; }
        public string AirportName { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
    }

    public class FlightPrice
    {
        public string Currency { get; set; }
        public string Total { get; set; }
    }

    public class Airline
    {
        public string IataCode { get; set; }
        public string Name { get; set; }
    }

    public class FlightLinks
    {
        public string FlightOffer { get; set; }
    }

    public class FlightDictionaries
    {
        public Dictionary<string, LocationInfo> Locations { get; set; }
        public Dictionary<string, string> Carriers { get; set; }
    }

    public class LocationInfo
    {
        public string SubType { get; set; }
        public string DetailedName { get; set; }
    }

    public class FlightMeta
    {
        public string Currency { get; set; }
        public string Source { get; set; }
        public string LastUpdated { get; set; }
    }
}
