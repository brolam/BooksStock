using System;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksStock.API.Models
{
    /// <summary>
    /// Informar o estoque atual de um livro.
    /// </summary>
    public class BookStock
    {
        private string _bookName;
        private int _stockQuantity;

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string BookID { get; set; }
        public string BookName
        {
            get { return _bookName; }
            set
            {
                if ((value == null) || (value.Length == 0))
                {
                    throw new System.Exception("Book Name não pode ser vazio");
                }
                _bookName = value;
            }
        }
        public int StockQuantity
        {
            get { return _stockQuantity; }
            set
            {
                if (value < 0)
                {
                    throw new System.Exception("Stock Quantity deve ser igual ou maior do zero!");
                }
                _stockQuantity = value;
            }
        }
        public DateTime StockUpdated { get; set; }
        public BookStock() { }

        public BookStock(string bookName, int stockQuantity)
        {
            this.BookName = bookName;
            this.StockQuantity = stockQuantity;
        }
    }
}