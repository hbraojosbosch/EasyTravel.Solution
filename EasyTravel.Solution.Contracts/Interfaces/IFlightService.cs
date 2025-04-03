using EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels;
using EasyTravel.Solution.Contracts.Contracts.Flights.Requests;
using EasyTravel.Solution.Contracts.Contracts.Flights.Responses;

namespace EasyTravel.Solution.Contracts.Interfaces
{
    public interface IFlightService
    {
        Task<FlightOfferResponseDto> GetFlights(FlightRequestDto flightRequestDto);
        Task<FlightDestinationsFromOriginResponseDto> GetFlightsOffersFromOrigin(string origin, DateTime? departureDate, int? travelDays, decimal? maxPrice);
    }
}
