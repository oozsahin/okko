using okko.uzapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi.Contracts
{
    public interface IPersonLocationRepository
    {
        Task<IList<PersonLocations>> PersonLocations();
    }
}
