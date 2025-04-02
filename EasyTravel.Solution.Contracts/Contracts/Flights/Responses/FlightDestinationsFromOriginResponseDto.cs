using System.Text.Json.Serialization;
using EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels;

namespace EasyTravel.Solution.Contracts.Contracts.Flights.Responses
{
    public class FlightDestinationsFromOriginResponseDto
    {
        public List<FlightDestinationsDto> Data { get; set; }

        public Dictionaries Dictionaries { get; set; }
    }

    public class FlightDestinationsDto
    {
        public string Type { get; set; }

        public string Origin { get; set; }


        public string Destination { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public FlightDestinationsFromOriginPriceDto Price { get; set; }

        public FlightDestinationsLinksDto Links { get; set; }
    }

    public class Dictionaries
    {
        public Dictionary<string, string> Currencies { get; set; }

        public Dictionary<string, FlightDestinationsLocationDto> Locations { get; set; }
    }

    public class FlightDestinationsLocationDto
    {
        public string SubType { get; set; }

        public string DetailedName { get; set; }
    }

    public class FlightDestinationsLinksDto
    {
        public string FlightDates { get; set; }

        public string FlightOffers { get; set; }
    }

    public class FlightDestinationsFromOriginPriceDto
    {
        public string Total { get; set; }
    }
}
