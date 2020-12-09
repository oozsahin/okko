using Okko.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Okko.Shared.Data
{
    public interface IDepositEndpoint
    {
        Task<IList<IDepositModel>> GetDeposits(string openDate);
        Task<IList<IDepositModel>> GetSomeDeposits(string branch, string openDate, string codeSubject, string fileName, string currency, string accounttype);
        Task<IList<IUzClientType>> GetUzClientType();
    }
}