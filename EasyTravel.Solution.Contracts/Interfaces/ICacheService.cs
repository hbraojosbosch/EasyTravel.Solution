using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Solution.Contracts.Interfaces
{
    public interface ICacheService
    {
        Task SetValueAsync(string key, string value);
        Task<string> GetValueAsync(string key);
    }
}
