using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTravel.Solution.Contracts.Contracts.Authentication;

namespace EasyTravel.Solution.Contracts.Interfaces
{
    public  interface IAuthenticationService
    {
        Task<AuthenticationResponseDto> GetTokenAsync(string apiKey, string apiSecret);
    }
}
