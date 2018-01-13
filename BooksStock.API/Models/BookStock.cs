using System;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksStock.API.Models
{
    /// <summary>
    /// Informar o estoque atual de um livro.
    /// </summary>
    public class BookStock
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string BookID { get; set; }
        public string BookName { get; set; }
        public int StockQuantity { get; set; }
        public DateTime StockUpdated { get; set; }
        public BookStock() { }

        public BookStock(string nome, int stockQuantity)
        {
            this.BookName = nome;
            this.StockQuantity = stockQuantity;
        }
    }
}