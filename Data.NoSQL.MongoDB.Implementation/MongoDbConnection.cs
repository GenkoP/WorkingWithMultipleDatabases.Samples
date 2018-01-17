using MongoDB.Driver;

namespace Data.NoSQL.MongoDB.Implementation
{
    public sealed class MongoDbConnection
    {
        private readonly IMongoDatabase database;

        public MongoDbConnection(string connectionString, string dataBaseName)
        {
            MongoClient client = new MongoClient(connectionString);
            database = client.GetDatabase(dataBaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return database.GetCollection<T>(name);
        }
    }
}
