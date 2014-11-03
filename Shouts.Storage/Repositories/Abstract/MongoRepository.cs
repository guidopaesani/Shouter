using MongoDB.Driver;

namespace Shouts.Storage.Repositories.Abstract
{
    public abstract class MongoRepository
    {
        protected string connectionString;
        protected MongoClient client;
        protected MongoServer server;
        protected MongoDatabase database;
        
        protected MongoRepository()
        {
            MongoConnection conn = new MongoConnection();
            connectionString = conn.connectionString;
            client = new MongoClient(connectionString);
            server = client.GetServer();
            database = server.GetDatabase(conn.database);
        }
    }
}
