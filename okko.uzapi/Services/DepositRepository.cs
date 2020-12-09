using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using okko.uzapi.Data;
using okko.uzapi.Contracts;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Dapper;
using AutoMapper;
using okko.uzapi.DTOs;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using Microsoft.AspNetCore.Mvc;
using okko.uzapi.Models;

namespace okko.uzapi.Services
{
    public class DepositRepository : IDepositRepository
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStrings _connectionStrings;
        public DepositRepository(IDataAccess dataAccess, IOptions<ConnectionStrings> connectionStrings)
        {
            _dataAccess = dataAccess;
            _connectionStrings = connectionStrings.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="openDate"></param>
        /// <returns></returns>
        public async Task<IList<DepositDto>> GetDeposits(string openDate)
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("p_branch", OracleDbType.Varchar2, ParameterDirection.Input, "H");
            parameters.Add("p_opendate", OracleDbType.Varchar2, ParameterDirection.Input, openDate);
            parameters.Add("p_codesubject", OracleDbType.Varchar2, ParameterDirection.Input, "H");
            parameters.Add("p_currency", OracleDbType.Varchar2, ParameterDirection.Input, "H");
            parameters.Add("p_deposittype", OracleDbType.Varchar2, ParameterDirection.Input, "H");
            parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
            return await _dataAccess.LoadData<DepositDto, dynamic>("RPT_SEL_DEPOSITS_SP",parameters, _connectionStrings.OracleConnectionString);
        }

        public async Task<IList<DepositDto>> GetSomeDeposits(string branch, string openDate, string codeSubject, string fileName, string currency, string accounttype)
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("p_branch", OracleDbType.Varchar2, ParameterDirection.Input, "H");
            parameters.Add("p_opendate", OracleDbType.Varchar2, ParameterDirection.Input, openDate);
            parameters.Add("p_codesubject", OracleDbType.Varchar2, ParameterDirection.Input, "H");
            parameters.Add("p_currency", OracleDbType.Varchar2, ParameterDirection.Input, "H");
            parameters.Add("p_deposittype", OracleDbType.Varchar2, ParameterDirection.Input, "H");
            parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
            return await _dataAccess.LoadData<DepositDto, dynamic>("RPT_SEL_DEPOSITSV2_SP", parameters, _connectionStrings.OracleConnectionString);
        }

        public async Task<IList<UzClientTypeDto>> GetUzClientType()
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
            return await _dataAccess.LoadData<UzClientTypeDto, dynamic>("rpt_sel_clienttype_sp", parameters, _connectionStrings.OracleConnectionString);          
        }

    }
}
