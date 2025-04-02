using System.Text.Json.Serialization;
using EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels;

namespace EasyTravel.Solution.Contracts.Contracts.Flights.Responses
{
    public class FlightDestinationFromOriginResponseDto
    {
        public List<FlightDestinationDto> Data { get; set; }

        public Dictionaries Dictionaries { get; set; }
    }

    public class FlightDestinationDto
    {
        public string Type { get; set; }

        public string Origin { get; set; }


        public string Destination { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public FlightDestinationFromOriginPriceDto Price { get; set; }

        public FlightDestinationLinksDto Links { get; set; }
    }

    public class Dictionaries
    {
        public Dictionary<string, string> Currencies { get; set; }

        public Dictionary<string, FlightDestinationLocationDto> Locations { get; set; }
    }

    public class FlightDestinationLocationDto
    {
        public string SubType { get; set; }

        public string DetailedName { get; set; }
    }

    public class FlightDestinationLinksDto
    {
        public string FlightDates { get; set; }

        public string FlightOffers { get; set; }
    }

    public class FlightDestinationFromOriginPriceDto
    {
        public string Total { get; set; }
    }
}
