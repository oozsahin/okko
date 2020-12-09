using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using okko.uzapi.Contracts;
using okko.uzapi.Data;
using okko.uzapi.DTOs;
using okko.uzapi.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi.Services
{
    public class SeedDataService //: ISeedDataService
    {
        IConfiguration configuration;
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        private readonly ConnectionStrings _connectionStrings;
        private readonly ILoggerService _logger;
        public SeedDataService(ApplicationDBContext db, IConfiguration _configuration, IMapper mapper, ILoggerService logger, IOptions<ConnectionStrings> connectionStrings)
        {
            _db = db;
            configuration = _configuration;
            _mapper = mapper;
            _logger = logger;
            _connectionStrings = connectionStrings.Value;
        }


        //public ICollection<ApplicationUser> SeedRoles(string branch, string openDate, string codeSubject, string fileName, string currency, string accounttype)
        //{
        //    var dyParam = new OracleDynamicParameters();
        //    dyParam.Add("p_branch", OracleDbType.Varchar2, ParameterDirection.Input, String.IsNullOrEmpty(branch) ? "H" : branch);
        //    dyParam.Add("p_opendate", OracleDbType.Varchar2, ParameterDirection.Input, openDate);
        //    dyParam.Add("p_codesubject", OracleDbType.Varchar2, ParameterDirection.Input, String.IsNullOrEmpty(codeSubject) ? "H" : codeSubject);
        //    dyParam.Add("p_currency", OracleDbType.Varchar2, ParameterDirection.Input, String.IsNullOrEmpty(currency) ? "H" : currency);
        //    dyParam.Add("p_deposittype", OracleDbType.Varchar2, ParameterDirection.Input, String.IsNullOrEmpty(accounttype) ? "H" : accounttype);
        //    dyParam.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
        //    var objDto = new List<DepositDto>();
        //    using (var conn = new OracleConnection(_connectionStrings.OracleConnectionString))
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();
        //        var query = "RPT_SEL_DEPOSITSV2_SP";
        //        var objList = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToList();
        //        foreach (var obj in objList)
        //        {
        //            DepositDto emp = new DepositDto();
        //            emp.Branch = obj.BRANCH;
        //            emp.Id_Client = obj.ID_CLIENT;
        //            emp.Date_Open = obj.DATE_OPEN;
        //            emp.Name = obj.NAME;
        //            emp.Id = obj.ID;
        //            emp.Balance_Account = obj.BALANCE_ACCOUNT;
        //            emp.Currency_Code = obj.CURRENCY_CODE;
        //            emp.s30 = Convert.ToDouble(obj.S30.ToString());
        //            emp.Id_Client2 = obj.ID_CLIENT;
        //            emp.Code_Subject = obj.CODE_SUBJECT;
        //            emp.File_Name = obj.FILE_NAME;
        //            emp.File_Name2 = obj.FILE_NAME2;
        //            emp.Account_Type = obj.DEPOSIT_TYPE;
        //            objDto.Add(emp);
        //        }
        //    }
        //    return objDto;
        //}

        public Task SeedUsers(UserManager<IdentityUser> userManager)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExistsRole(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExistsUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
