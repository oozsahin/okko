using Dapper;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using okko.uzapi.Models;

namespace okko.uzapi.Data
{
    public class OracleDb : IDataAccess
    {
        private readonly IConfiguration _config;

        public OracleDb(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IList<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                var rows = await connection.QueryAsync<T>(storedProcedure,
                                                          parameters,
                                                          commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
        }

        public async Task<ComboBoxViewModel> LoadMultipleData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            ComboBoxViewModel refData = new ComboBoxViewModel();
            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                using (var multi = await connection.QueryMultipleAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure))
                {
                    refData.PersonLocationList = multi.Read<PersonLocations>().ToList();
                    refData.PersonPositionList = multi.Read<PersonPositions>().ToList();
                    refData.PersonTitleList = multi.Read<PersonTitles>().ToList();
                }
            }
            return refData;
        }
        public async Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new OracleConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                return await connection.ExecuteAsync(storedProcedure,
                                                     parameters,
                                                     commandType: CommandType.StoredProcedure);
            }
        }

        //public async Task<ContactReferenceData> Get()
        //{
        //    var sql = "EXEC usp_GetCountries; EXEC usp_GetCompanies; EXEC usp_GetGroups; EXEC usp_GetGroupPositions";
        //    ContactReferenceData refData = new ContactReferenceData();
        //    try
        //    {
        //        using (IDbConnection dbConnection = _connection)
        //        {
        //            using (var multi = connection.QueryMultipleAsync(sql: sql, commandType: CommandType.StoredProcedure).Result)
        //            {
        //                refData.CountryDetails = multi.Read<countryDetails>().ToList();
        //                refData.CompanyDetails = multi.Read<CompanyDetails>().ToList();
        //                refData.GroupData = multi.Read<Groups>().ToList();
        //                refData.GroupPositionsData = multi.Read<GroupPositions>().ToList();
        //            }
        //        }
        //        return refData;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        throw;
        //    }
        //}


        //public static void OutputParameters(string firstName, string lastName)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        var p = new DynamicParameters();
        //        p.Add("@Id", 0, DbType.Int32, ParameterDirection.Output);
        //        p.Add("@FirstName", firstName);
        //        p.Add("@LastName", lastName);

        //        string sql = $@"insert into dbo.Person (FirstName, LastName) 
        //                        values (@FirstName, @LastName);
        //                        select @Id = @@IDENTITY";

        //        cnn.Execute(sql, p);

        //        int newIdentity = p.Get<int>("@Id");

        //        Console.WriteLine($"The new Id is { newIdentity }");
        //    }
        //}

        //public static void RunWithTransaction(string firstName, string lastName)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        var p = new DynamicParameters();
        //        p.Add("@FirstName", firstName);
        //        p.Add("@LastName", lastName);

        //        string sql = $@"insert into dbo.Person (FirstName, LastName) 
        //                        values (@FirstName, @LastName)";

        //        cnn.Open();
        //        using (var trans = cnn.BeginTransaction())
        //        {
        //            int recordsUpdated = cnn.Execute(sql, p, trans);

        //            Console.WriteLine($"Records Updated: { recordsUpdated }");

        //            try
        //            {
        //                cnn.Execute("update dbo.Person set LastName = '1'", transaction: trans);
        //                trans.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine($"Error: { ex.Message }");
        //                trans.Rollback();
        //            }
        //        }
        //    }

        //    Console.WriteLine();
        //    MapMultipleObjects();
        //}

    }
}
