using System;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using System.Linq;
using BooksStock.API.Models;

namespace BooksStock.API.Repository
{
    public class BooksStockRepository
    {
        private MongoDatabase _database;
        private string _tableName;
        private MongoCollection<BookStock> _booksStock;

        /// <summary>
        /// Construir o banco de dados e tabela
        /// </summary>
        /// <param name="db">Banco de dados</param>
        /// <param name="tableName">Nome da tabela</param>        
        public BooksStockRepository(MongoDatabase db, string tableName)
        {
            _database = db;
            _tableName = tableName;
            _booksStock = _database.GetCollection<BookStock>(tableName);
        }

        /// <summary>
        /// Adicionar um BookStock e atualizar a data do estoque. 
        /// </summary>
        /// <param name="newBookStock"></param>
        public void Add(BookStock newBookStock)
        {
            newBookStock.StockUpdated = DateTime.Now;
            _booksStock.Insert(newBookStock);
        }

        /// <summary>
        /// Recupepar um BookStock por ID
        /// </summary>
        /// <param name="bookID">informar uma string com o id do BookStock/param>
        /// <returns>Um BookStock ou Null para um ID inválido</returns>
        public BookStock Get(string bookID) => _booksStock.FindOneById(ObjectId.Parse(bookID));

        /// <summary>
        /// Recuperar todos os BooksStock ordernado por um campo.
        /// </summary>
        /// <param name="fieldAscendingOrder">Informar o nome do campo</param>
        /// <returns>Todos os BooksStock por ordem ascendente</returns>
        public IQueryable<BookStock> GetAll(string fieldAscendingOrder)
        {
            var sortBy = SortBy.Ascending(fieldAscendingOrder);
            MongoCursor<BookStock> cursor = _booksStock.FindAll().SetSortOrder(sortBy);
            return cursor.AsQueryable<BookStock>();
        }

        /// <summary>
        /// Atualizar um BookStock
        /// </summary>
        /// <param name="bookStockUpdated">Informar o BookStock atualizado</param>
        public void Update(BookStock bookStockUpdated) => _booksStock.Save(bookStockUpdated);

        /// <summary>
        /// Excluir um BookStock
        /// </summary>
        /// <param name="bookID">Informar o id do BookStock </param>
        public void Delete(string bookID)
        {
            var deleteQuery = Query<BookStock>.EQ(bookStock => bookStock.BookID, bookID);
            _booksStock.Remove(deleteQuery);
        }
    }
}