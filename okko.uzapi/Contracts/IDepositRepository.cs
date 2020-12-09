using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using okko.uzapi.DTOs;

namespace okko.uzapi.Contracts
{
    public interface IDepositRepository 
    {
        Task<IList<DepositDto>> GetDeposits(string openDate);
        Task<IList<DepositDto>> GetSomeDeposits(string branch, string openDate, string codeSubject, string file_name, string currency, string accounttype);
        Task<IList<UzClientTypeDto>> GetUzClientType();
    }

}
