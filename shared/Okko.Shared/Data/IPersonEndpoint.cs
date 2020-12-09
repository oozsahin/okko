using Okko.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Okko.Shared.Data
{
    public interface IPersonEndpoint
    {
        Task CreatePerson(IPersonModel person, string recordUser);
        Task DeletePerson(int id);
        Task<List<IPersonModel>> ReadPerson();
        Task<IPersonModel> ReadPerson(int id);
        Task<List<IPersonModel>> SearchPerson(string searchTerm);
        Task UpdatePerson(IPersonModel person, string recordUser);
    }
}