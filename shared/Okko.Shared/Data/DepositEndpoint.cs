using Okko.Shared.DataAccess;
using Okko.Shared.Helpers;
using Okko.Shared.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okko.Shared.Data
{
    public class DepositEndpoint : IDepositEndpoint
    {
        private readonly IOracleDataAccess _dataAccess;

        public DepositEndpoint(IOracleDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IList<IDepositModel>> GetDeposits(string openDate)
        {
            IList<DepositModel> deposit = null;
            try
            {
                OracleDynamicParameters parameters = new OracleDynamicParameters();
                parameters.Add("p_branch", OracleDbType.Varchar2, ParameterDirection.Input, "H");
                parameters.Add("p_opendate", OracleDbType.Varchar2, ParameterDirection.Input, openDate);
                parameters.Add("p_codesubject", OracleDbType.Varchar2, ParameterDirection.Input, "H");
                parameters.Add("p_currency", OracleDbType.Varchar2, ParameterDirection.Input, "H");
                parameters.Add("p_deposittype", OracleDbType.Varchar2, ParameterDirection.Input, "H");
                parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
                deposit = await _dataAccess.LoadData<DepositModel, dynamic>("RPT_SEL_DEPOSITS_SP", parameters, "OracleConnectionString");
            }
            catch (Exception e)
            {
                Utils.NLogMessage(this.GetType(), $" {e.Message} - {e.InnerException}", Utils.NLogType.Error);
            }
            return deposit.ToList<IDepositModel>();
        }

        public async Task<IList<IDepositModel>> GetSomeDeposits(string branch, string openDate, string codeSubject, string fileName, string currency, string accounttype)
        {
            IList<DepositModel> deposit = null;
            try
            {
                OracleDynamicParameters parameters = new OracleDynamicParameters();
                parameters.Add("p_branch", OracleDbType.Varchar2, ParameterDirection.Input, "H");
                parameters.Add("p_opendate", OracleDbType.Varchar2, ParameterDirection.Input, openDate);
                parameters.Add("p_codesubject", OracleDbType.Varchar2, ParameterDirection.Input, "H");
                parameters.Add("p_currency", OracleDbType.Varchar2, ParameterDirection.Input, "H");
                parameters.Add("p_deposittype", OracleDbType.Varchar2, ParameterDirection.Input, "H");
                parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
                deposit = await _dataAccess.LoadData<DepositModel, dynamic>("RPT_SEL_DEPOSITSV2_SP", parameters, "OracleConnectionString");
            }
            catch (Exception e)
            {
                Utils.NLogMessage(this.GetType(), $" {e.Message} - {e.InnerException}", Utils.NLogType.Error);
            }
            return deposit.ToList<IDepositModel>();
        }

        public async Task<IList<IUzClientType>> GetUzClientType()
        {
            IList<UzClientType> clientType = null;
            try
            {
                OracleDynamicParameters parameters = new OracleDynamicParameters();
                parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
                clientType = await _dataAccess.LoadData<UzClientType, dynamic>("rpt_sel_clienttype_sp", parameters, "OracleConnectionString");
            }
            catch (Exception e)
            {
                Utils.NLogMessage(this.GetType(), $" {e.Message} - {e.InnerException}", Utils.NLogType.Error);
            }
            return clientType.ToList<IUzClientType>(); ;
        }

    }
}
