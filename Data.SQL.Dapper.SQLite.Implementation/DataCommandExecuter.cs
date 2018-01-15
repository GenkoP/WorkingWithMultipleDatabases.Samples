using System.Data;
using System.Data.SQLite;
using Dapper;
using Data.SQL.Common.Contracts;

namespace Data.SQL.Dapper.Implementation
{
    public sealed class DataCommandExecuter : IDataCommandExecuter
    {
        private readonly IDbConnection dbConnection;

        public DataCommandExecuter(string connectionString)
        {
            dbConnection = new SQLiteConnection(connectionString);
        }

        public void Execute(string dataCommand)
        {
            dbConnection.Execute(dataCommand);
        }
    }
}
