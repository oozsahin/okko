using Microsoft.Extensions.Options;
using okko.uzapi.Contracts;
using okko.uzapi.Data;
using okko.uzapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi.Services
{
    public class PersonLocationRepository : IPersonLocationRepository
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStrings _connectionStrings;
        public PersonLocationRepository(IDataAccess dataAccess, IOptions<ConnectionStrings> connectionStrings)
        {
            _dataAccess = dataAccess;
            _connectionStrings = connectionStrings.Value;
        }
        public Task<IList<PersonLocations>> PersonLocations()
        {
            throw new NotImplementedException();
        }
    }
}
