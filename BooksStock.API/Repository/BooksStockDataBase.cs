using MongoDB.Driver;
using System.Configuration;

namespace BooksStock.API.Repository
{
    public class BooksStockDataBase
    {
        private MongoDatabase _database;

        public BooksStockDataBase()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = server.GetDatabase(databaseName);
        }
    }
}