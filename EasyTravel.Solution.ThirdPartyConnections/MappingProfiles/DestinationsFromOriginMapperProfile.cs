using AutoMapper;
using EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels;
using EasyTravel.Solution.Contracts.Contracts.Flights.Responses;

namespace EasyTravel.Solution.ThirdPartyConnections.MappingProfiles
{
    public class DestinationsFromOriginMapperProfile : Profile
    {
        public DestinationsFromOriginMapperProfile()
        {
            CreateMap<AmadeusFlightDestinationsFromOriginResponseDto, FlightDestinationsFromOriginResponseDto>();
            CreateMap<AmadeusFlightDestinationsDto, FlightDestinationsDto>();
            CreateMap<AmadeusFlightDestinationsPriceDto, FlightDestinationsFromOriginPriceDto>();
            CreateMap<AmadeusFlightDestinationsLinksDto, FlightDestinationsLinksDto>();
            CreateMap<AmadeusFlightDestinationsLocationDto, FlightDestinationsLocationDto>();
            CreateMap<AmadeusDictionaries, Dictionaries>();
        }
    }
}
