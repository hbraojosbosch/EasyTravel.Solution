using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels
{
    public class MetaLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}
