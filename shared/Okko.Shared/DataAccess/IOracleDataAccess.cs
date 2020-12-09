using Okko.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Okko.Shared.DataAccess
{
    public interface IOracleDataAccess
    {
        Task<IList<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
        Task<ComboBoxViewModel> LoadMultipleData<T, U>(string storedProcedure, U parameters, string connectionStringName);
    }
}