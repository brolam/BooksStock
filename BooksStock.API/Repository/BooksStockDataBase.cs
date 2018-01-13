using MongoDB.Driver;
using System.Configuration;
using BooksStock.API.Models;
using System;

namespace BooksStock.API.Repository
{
    public class BooksStockDataBase
    {
        private MongoDatabase _database;
        protected BooksStockRepository _booksStock;

        public BooksStockDataBase()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = server.GetDatabase(databaseName);
        }

        public BooksStockRepository BooksStock
        {
            get
            {
                if (_booksStock == null)
                    _booksStock = new BooksStockRepository(_database, "booksStock");

                return _booksStock;
            }
        }
        /// <summary>
        /// Excluir o banco de dados e todas as tabelas.
        /// </summary>
        public void DropDataBase()
        {
            _database.Drop();
        }
    }
}