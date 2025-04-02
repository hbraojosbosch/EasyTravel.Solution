using AutoMapper;
using EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels;
using EasyTravel.Solution.Contracts.Contracts.Flights.Responses;

namespace EasyTravel.Solution.ThirdPartyConnections
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AmadeusFlightDestinationFromOriginResponseDto, FlightDestinationFromOriginResponseDto>();
            CreateMap<AmadeusFlightDestinationDto, FlightDestinationDto>();
            CreateMap<AmadeusFlightDestinationPriceDto, FlightDestinationFromOriginPriceDto>();
            CreateMap<AmadeusFlightDestinationLinksDto, FlightDestinationLinksDto>();
            CreateMap<AmadeusFlightDestinationLocationDto, FlightDestinationLocationDto>();
            CreateMap<AmadeusDictionaries, Dictionaries>();                   
        }
    }
}
