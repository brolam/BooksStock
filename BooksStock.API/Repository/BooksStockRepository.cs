﻿using System;
using MongoDB.Driver;
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
        /// <param name="entity"></param>
        public void Add(BookStock bookStock)
        {
            bookStock.StockUpdated = DateTime.Now;
            _booksStock.Insert(bookStock);
        }

    }
}