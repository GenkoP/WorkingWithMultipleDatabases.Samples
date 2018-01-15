using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Data.SQL.Common.Contracts;

namespace Data.SQL.Dapper.Implementation
{
    public sealed class DataCommandExecuter : IDataCommandExecuter
    {
        private readonly IDbConnection dbConnection;

        public DataCommandExecuter(string connectionStringName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            dbConnection = new SqlConnection(connectionString);
        }

        public void Execute(string dataCommand)
        {
            dbConnection.Execute(dataCommand);
        }
    }
}
