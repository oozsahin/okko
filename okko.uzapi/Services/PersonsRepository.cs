using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using okko.uzapi.Contracts;
using okko.uzapi.Data;
using okko.uzapi.DTOs;
using okko.uzapi.Models;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi.Services
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStrings _connectionStrings;
        public PersonsRepository(IDataAccess dataAccess, IOptions<ConnectionStrings> connectionStrings)
        {
            _dataAccess = dataAccess;
            _connectionStrings = connectionStrings.Value;
        }
        
        public async Task<bool> Create(Persons entity)
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("p_FirsName", OracleDbType.Varchar2, ParameterDirection.Input, entity.Firstname);
            parameters.Add("p_LastName", OracleDbType.Varchar2, ParameterDirection.Input, entity.Lastname);
            parameters.Add("p_Title", OracleDbType.Varchar2, ParameterDirection.Input, entity.Title);
            parameters.Add("p_Position", OracleDbType.Varchar2, ParameterDirection.Input, entity.Position);
            parameters.Add("p_Yocation", OracleDbType.Varchar2, ParameterDirection.Input, entity.Location);
            parameters.Add("p_Ipt", OracleDbType.Varchar2, ParameterDirection.Input, entity.IPT);
            parameters.Add("p_Celphone", OracleDbType.Varchar2, ParameterDirection.Input, entity.CellPhone);
            parameters.Add("p_RecordUser", OracleDbType.Varchar2, ParameterDirection.Input, entity.RecordUser);
            await _dataAccess.SaveData("GEN_INS_PERSON_SP", parameters, _connectionStrings.OracleConnectionString);
            return true;
        }

        public async Task<bool> Delete(Persons entity)
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("p_ID", OracleDbType.Int32, ParameterDirection.Input, entity.Id);
            parameters.Add("p_RecordUser", OracleDbType.Varchar2, ParameterDirection.Input, entity.RecordUser);
            await _dataAccess.SaveData("GEN_DEL_PERSON_SP", parameters, _connectionStrings.OracleConnectionString);
            return true;
        }

        public async Task<IList<Persons>> FindAll()
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
            return await _dataAccess.LoadData<Persons, dynamic>("GEN_SEL_PERSONS_SP", parameters, _connectionStrings.OracleConnectionString);
        }

        public async Task<Persons> FindById(int id)
        {        
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("p_ID", OracleDbType.Int32, ParameterDirection.Input, id);
            parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
            var recs = await _dataAccess.LoadData<Persons, dynamic>("GEN_SEL_PERSONS_SP", parameters, _connectionStrings.OracleConnectionString);
            return recs.FirstOrDefault();
        }

        public Task<bool> isExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Update(Persons entity)
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("p_ID", OracleDbType.Int32, ParameterDirection.Input, entity.Id);
            parameters.Add("p_FirsName", OracleDbType.Varchar2, ParameterDirection.Input, entity.Firstname);
            parameters.Add("p_lastname", OracleDbType.Varchar2, ParameterDirection.Input, entity.Lastname);
            parameters.Add("p_title", OracleDbType.Varchar2, ParameterDirection.Input, entity.Title);
            parameters.Add("p_position", OracleDbType.Varchar2, ParameterDirection.Input, entity.Position);
            parameters.Add("p_location", OracleDbType.Varchar2, ParameterDirection.Input, entity.Location);
            parameters.Add("p_ipt", OracleDbType.Varchar2, ParameterDirection.Input, entity.IPT);
            parameters.Add("p_celphone", OracleDbType.Varchar2, ParameterDirection.Input, entity.CellPhone);
            parameters.Add("p_RecordUser", OracleDbType.Varchar2, ParameterDirection.Input, entity.RecordUser);
            await _dataAccess.SaveData("GEN_UPD_PERSON_SP", parameters, _connectionStrings.OracleConnectionString);
            return true;
        }

        public async Task<ComboBoxViewModel> AllComboboxData()
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);
            parameters.Add("RC2", OracleDbType.RefCursor, ParameterDirection.Output);
            parameters.Add("RC3", OracleDbType.RefCursor, ParameterDirection.Output);
            return await _dataAccess.LoadMultipleData<ComboBoxViewModel, dynamic>("GEN_SEL_ALLCOMBOBOXDATA_SP", parameters, _connectionStrings.OracleConnectionString);
        }


    }
}
