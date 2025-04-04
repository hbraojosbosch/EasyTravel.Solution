using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels;
using EasyTravel.Solution.Contracts.Contracts.Flights.Responses;

namespace EasyTravel.Solution.ThirdPartyConnections.MappingProfiles
{
    public class FlightOfferMapperProfile : Profile
    {
        public FlightOfferMapperProfile()
        {
            CreateMap<AmadeusFlightOfferResponseDto, FlightOfferResponseDto>();
            CreateMap<AmadeusFlightOfferDto, FlightOfferDto>();
            CreateMap<AmadeusItineraryDto, FlightOfferItineraryDto>();
            CreateMap<AmadeusPriceDto, FlightOfferPriceDto>();
            CreateMap<AmadeusPricingOptionsDto, FlightOfferPricingOptionsDto>();
            CreateMap<AmadeusFeeDto, FlightOfferFeeDto>();
            CreateMap<AmadeusSegmentDto, FlightOfferSegmentDto>();
            CreateMap<AmadeusDepartureArrivalDto, FlightOfferDepartureArrivalDto>();
            CreateMap<AmadeusDictionariesDto, FlightOfferDictionariesDto>();
            CreateMap<AmadeusAircraftDto, FlightOfferAircraftDto>();
            CreateMap<AmadeusTravelerPricingDto, FlightOfferTravelerPricingDto>();
            CreateMap<AmadeusFareDetailsBySegmentDto, FlightOfferFareDetailsBySegmentDto>();
            CreateMap<AmadeusIncludedCheckedBagsDto, FlightOfferIncludedCheckedBagsDto>();
            CreateMap<AmadeusLocationCodesDto, FlightOfferLocationDto>();
        }
    }
}
