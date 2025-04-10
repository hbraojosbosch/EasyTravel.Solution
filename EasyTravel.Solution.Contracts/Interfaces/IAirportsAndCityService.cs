﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTravel.Solution.Contracts.Contracts.Authentication;
using EasyTravel.Solution.Contracts.Contracts.Flights.AmadeusModels;

namespace EasyTravel.Solution.Contracts.Interfaces
{
    public interface IAirportsAndCityService
    {
        Task<List<AmadeusLocationInfoResponseDto>> GetLocationsAsync();
        Task<List<AmadeusLocationInfoResponseDto>> GetLocationsAsync(List<string> Cities, string token);
        Task SetLocationToMemoryCacheAsync();
    }
}
