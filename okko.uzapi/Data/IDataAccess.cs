using okko.uzapi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace okko.uzapi.Data
{
    public interface IDataAccess
    {
        Task<IList<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
        Task<ComboBoxViewModel> LoadMultipleData<T, U>(string storedProcedure, U parameters, string connectionStringName);
    }
}