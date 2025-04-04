using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class AmadeusLocationInfoDto
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("data")]
        public List<LocationData> Data { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("links")]
        public MetaLinks Links { get; set; }
    }

    public class LocationData
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("subType")]
        public string SubType { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("detailedName")]
        public string DetailedName { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("self")]
        public SelfLink Self { get; set; }

        [JsonPropertyName("timeZoneOffset")]
        public string TimeZoneOffset { get; set; }

        [JsonPropertyName("iataCode")]
        public string IataCode { get; set; }

        [JsonPropertyName("geoCode")]
        public GeoCode GeoCode { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("analytics")]
        public Analytics Analytics { get; set; }
    }      

    public class SelfLink
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("methods")]
        public List<string> Methods { get; set; }
    }

    public class GeoCode
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("cityName")]
        public string CityName { get; set; }

        [JsonPropertyName("cityCode")]
        public string CityCode { get; set; }

        [JsonPropertyName("countryName")]
        public string CountryName { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("regionCode")]
        public string RegionCode { get; set; }
    }

    public class Analytics
    {
        [JsonPropertyName("travelers")]
        public Travelers Travelers { get; set; }
    }

    public class Travelers
    {
        [JsonPropertyName("score")]
        public int Score { get; set; }
    }

}
