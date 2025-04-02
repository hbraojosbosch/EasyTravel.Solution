using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Solution.Contracts.Contracts.Flights.Requests
{
    public class FlightRequestDto
    {
        public string? DepartureStation { get; set; }
        public string? ArrivalStation { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
