using Okko.Shared.DataAccess;
using Okko.Shared.Models;
using Okko.Shared.Helpers;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okko.Shared.Data
{
    public class PersonEndpoint : IPersonEndpoint
    {
        private readonly IOracleDataAccess _dataAccess;
        public PersonEndpoint(IOracleDataAccess dataAccess) //, ILogger<PersonEndpoint> logger)
        {
            _dataAccess = dataAccess;
            //_logger = logger;

        }

        public async Task CreatePerson(IPersonModel person, string recordUser)
        {
            Utils.NLogMessage(this.GetType(),$"{"Create Person"}",Utils.NLogType.Info);
            try
            {
                OracleDynamicParameters parameters = new OracleDynamicParameters();
                parameters.Add("p_FirsName", OracleDbType.Varchar2, ParameterDirection.Input, person.Firstname);
                parameters.Add("p_LastName", OracleDbType.Varchar2, ParameterDirection.Input, person.Lastname);
                parameters.Add("p_TitleId", OracleDbType.Varchar2, ParameterDirection.Input, person.TitleId);
                parameters.Add("p_PositionId", OracleDbType.Varchar2, ParameterDirection.Input, person.PositionId);
                parameters.Add("p_LocationId", OracleDbType.Varchar2, ParameterDirection.Input, person.LocationId);
                parameters.Add("p_Ipt", OracleDbType.Varchar2, ParameterDirection.Input, person.IPT);
                parameters.Add("p_Celphone", OracleDbType.Varchar2, ParameterDirection.Input, person.CellPhone);
                parameters.Add("p_RecordUser", OracleDbType.Varchar2, ParameterDirection.Input, recordUser);
                parameters.Add("p_DateOfBirth", OracleDbType.Date, ParameterDirection.Input, person.DateOfBirth);
                await _dataAccess.SaveData("GEN_INS_PERSON_SP", parameters, "OracleConnectionString");
            }
            catch (Exception e)
            {
                Utils.NLogMessage(this.GetType(), $" {e.Message} - {e.InnerException}", Utils.NLogType.Error);
            }
        }

        public async Task<List<IPersonModel>> ReadPerson()
        {
            Utils.NLogMessage(this.GetType(), $"{"Read Person"}", Utils.NLogType.Info);
            
            IList<PersonModel> person = null;
            try
            {
                OracleDynamicParameters parameters = new OracleDynamicParameters();
                parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
                person = await _dataAccess.LoadData<PersonModel, dynamic>("GEN_SEL_PERSONS_SP", parameters, "OracleConnectionString");
            }
            catch (Exception e)
            {
                Utils.NLogMessage(this.GetType(), $" {e.Message} - {e.InnerException}", Utils.NLogType.Error);
            }
            return person.ToList<IPersonModel>();
        }

        public async Task<IPersonModel> ReadPerson(int id)
        {
            Utils.NLogMessage(this.GetType(), $"{"Read Person By Id"}", Utils.NLogType.Info);

            IList<PersonModel> person = null;
            try
            {
                OracleDynamicParameters parameters = new OracleDynamicParameters();
                parameters.Add("p_ID", OracleDbType.Varchar2, ParameterDirection.Input, id);
                parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
                person = await _dataAccess.LoadData<PersonModel, dynamic>("GEN_SEL_PERSONBYID_SP", parameters, "OracleConnectionString");
            }
            catch (Exception e)
            {
                Utils.NLogMessage(this.GetType(), $" {e.Message} - {e.InnerException}", Utils.NLogType.Error);
            }
            return person.FirstOrDefault();
        }

        public async Task UpdatePerson(IPersonModel person,string recordUser)
        {
            Utils.NLogMessage(this.GetType(), $"{"Update Person"}", Utils.NLogType.Info);
            try
            {
                OracleDynamicParameters parameters = new OracleDynamicParameters();
                parameters.Add("p_FirsName", OracleDbType.Varchar2, ParameterDirection.Input, person.Firstname);
                parameters.Add("p_FirsName", OracleDbType.Varchar2, ParameterDirection.Input, person.Firstname);
                parameters.Add("p_LastName", OracleDbType.Varchar2, ParameterDirection.Input, person.Lastname);
                parameters.Add("p_TitleId", OracleDbType.Varchar2, ParameterDirection.Input, person.TitleId);
                parameters.Add("p_PositionId", OracleDbType.Varchar2, ParameterDirection.Input, person.PositionId);
                parameters.Add("p_LocationId", OracleDbType.Varchar2, ParameterDirection.Input, person.LocationId);
                parameters.Add("p_Ipt", OracleDbType.Varchar2, ParameterDirection.Input, person.IPT);
                parameters.Add("p_Celphone", OracleDbType.Varchar2, ParameterDirection.Input, person.CellPhone);
                parameters.Add("p_RecordUser", OracleDbType.Varchar2, ParameterDirection.Input, recordUser);
                parameters.Add("p_DateOfBirth", OracleDbType.Date, ParameterDirection.Input, person.DateOfBirth);
                await _dataAccess.SaveData("GEN_UPD_PERSON_SP", parameters, "OracleConnectionString");
            }
            catch (Exception e)
            {
                Utils.NLogMessage(this.GetType(), $" {e.Message} - {e.InnerException}", Utils.NLogType.Error);
            }
        }

        public async Task DeletePerson(int id)
        {
            Utils.NLogMessage(this.GetType(), $"{"Delete Person"}", Utils.NLogType.Info);
            try
            {
                OracleDynamicParameters parameters = new OracleDynamicParameters();
                parameters.Add("p_ID", OracleDbType.Int32, ParameterDirection.Input, id);
                parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
                await _dataAccess.SaveData("GEN_DEL_PERSON_SP", parameters, "OracleConnectionString");
            }
            catch (Exception e)
            {
                Utils.NLogMessage(this.GetType(), $" {e.Message} - {e.InnerException}", Utils.NLogType.Error);
            }
        }
        public async Task<List<IPersonModel>> SearchPerson(string searchTerm)
        {
            Utils.NLogMessage(this.GetType(), $"{"Search Person"}", Utils.NLogType.Info);

            IList<PersonModel> person = null;
            try
            {
                OracleDynamicParameters parameters = new OracleDynamicParameters();
                parameters.Add("p_SearchTerm", OracleDbType.Varchar2, ParameterDirection.Input, searchTerm);
                parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
                person = await _dataAccess.LoadData<PersonModel, dynamic>("GEN_SEL_SEARCHPERSON_SP", parameters, "OracleConnectionString");
            }
            catch (Exception e)
            {
                Utils.NLogMessage(this.GetType(), $" {e.Message} - {e.InnerException}", Utils.NLogType.Error);
            }
            return person.ToList<IPersonModel>();
        }
    }
}
