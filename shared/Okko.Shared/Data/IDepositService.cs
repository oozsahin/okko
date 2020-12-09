using Okko.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Okko.Shared.Data
{
    public interface IDepositService
    {
        Task<List<DepositModel>> GetSomeDeposits();
    }
}