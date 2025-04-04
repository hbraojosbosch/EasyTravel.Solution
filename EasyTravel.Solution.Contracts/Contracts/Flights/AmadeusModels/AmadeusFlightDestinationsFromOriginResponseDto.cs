using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels
{
    public class AmadeusFlightDestinationsFromOriginResponseDto
    {
        [JsonPropertyName("data")]
        public List<AmadeusFlightDestinationsDto> Data { get; set; }

        [JsonPropertyName("dictionaries")]
        public AmadeusDictionaries Dictionaries { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }

    public class AmadeusFlightDestinationsDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("departureDate")]
        public DateTime DepartureDate { get; set; }

        [JsonPropertyName("returnDate")]
        public DateTime ReturnDate { get; set; }

        [JsonPropertyName("price")]
        public AmadeusFlightDestinationsPriceDto Price { get; set; }

        [JsonPropertyName("links")]
        public AmadeusFlightDestinationsLinksDto Links { get; set; }
    }

    public class AmadeusFlightDestinationsPriceDto
    {
        [JsonPropertyName("total")]
        public string Total { get; set; }
    }

    public class AmadeusFlightDestinationsLinksDto
    {
        [JsonPropertyName("flightDates")]
        public string FlightDates { get; set; }

        [JsonPropertyName("flightOffers")]
        public string FlightOffers { get; set; }
    }

    public class AmadeusDictionaries
    {
        [JsonPropertyName("currencies")]
        public Dictionary<string, string> Currencies { get; set; }

        [JsonPropertyName("locations")]
        public Dictionary<string, AmadeusFlightDestinationsLocationDto> Locations { get; set; }
    }

    public class AmadeusFlightDestinationsLocationDto
    {
        [JsonPropertyName("subType")]
        public string SubType { get; set; }

        [JsonPropertyName("detailedName")]
        public string DetailedName { get; set; }
    }

    public class AmadeusFlightDestinationsMeta
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("links")]
        public MetaLinks Links { get; set; }

        [JsonPropertyName("defaults")]
        public MetaDefaults Defaults { get; set; }
    }

    public class MetaDefaults
    {
        [JsonPropertyName("oneWay")]
        public bool OneWay { get; set; }

        [JsonPropertyName("nonStop")]
        public bool NonStop { get; set; }

        [JsonPropertyName("viewBy")]
        public string ViewBy { get; set; }
    }
}
