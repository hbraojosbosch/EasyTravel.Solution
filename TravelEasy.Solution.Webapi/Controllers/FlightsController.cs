using EasyTravel.Solution.Contracts.Contracts.Flights.Requests;
using EasyTravel.Solution.Contracts.Contracts.Flights.Responses;
using EasyTravel.Solution.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TravelEasy.Solution.Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        IFlightService _flightService { get; }

        private readonly ILogger<FlightsController> _logger;

        public FlightsController(ILogger<FlightsController> logger, IFlightService flightService)
        {
            _flightService = flightService;
            _logger = logger;
        }

        [HttpPost("get-flights")]
        [ProducesResponseType(typeof(FlightOfferResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGlights(FlightRequestDto flightRequestDto)
        {
            var response = await _flightService.GetFlights(flightRequestDto);
            if (response != null)
                return Ok(response);

            return NotFound();
        }

        [HttpGet("get-fights-offers-from-origin")]
        [ProducesResponseType(typeof(List<FlightDestinationsFromOriginResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFlightsOffersFromArigin([FromQuery] string origin, [FromQuery] DateTime? departureDate,
                                                                                [FromQuery] int? travelTotalDays, [FromQuery] decimal? maxPrice)
        {
            var response = await _flightService.GetFlightsOffersFromOrigin(origin, departureDate, travelTotalDays, maxPrice);

            return Ok(response);
        }
    }
}
