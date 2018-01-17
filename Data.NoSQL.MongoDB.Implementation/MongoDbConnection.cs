using System;
using MongoDB.Driver;

namespace Data.NoSQL.MongoDB.Implementation
{
    public sealed class MongoDbConnection
    {
        private readonly IMongoDatabase database;

        public MongoDbConnection(string connectionString, string dataBaseName)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException($"{nameof(connectionString)} should not be null or white-space");
            }

            if (string.IsNullOrWhiteSpace(dataBaseName))
            {
                throw new ArgumentException($"{nameof(dataBaseName)} should not be null or white-space");
            }

            MongoClient client = new MongoClient(connectionString);
            database = client.GetDatabase(dataBaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return database.GetCollection<T>(name);
        }
    }
}
