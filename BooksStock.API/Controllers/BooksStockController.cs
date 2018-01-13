using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Linq;
using BooksStock.API.Repository;
using BooksStock.API.Models;

namespace BooksStock.API.Controllers
{
    public class BooksStockController : ApiController
    {
        private readonly BooksStockDataBase _booksStockDataBase;

        public BooksStockController()
        {
            _booksStockDataBase = new BooksStockDataBase();
        }

        /// <summary>
        /// Recuperar todos os BooksStock ordernado por um campo.
        /// </summary>
        /// <param name="fieldAscendingOrder">Informar o nome do campo</param>
        /// <returns>Todos os BooksStock por ordem ascendente</returns>
        public IEnumerable<BookStock> GetAll(string fieldAscendingOrder)
        {
            var booksStockCurso = _booksStockDataBase.BooksStock.GetAll("BookName").GetEnumerator();
            List<BookStock> booksStock = new List<BookStock>();
            while (booksStockCurso.MoveNext())
            {
                var bookStock = booksStockCurso.Current;
                booksStock.Add(bookStock);
            }
            return booksStock;

        }

        /// <summary>
        /// Recupepar um BookStock por ID
        /// </summary>
        /// <param name="bookID">informar uma string com o id do BookStock/param>
        /// <returns>Um BookStock ou Null para um ID inválido</returns>
        public BookStock Get(string bookID) => _booksStockDataBase.BooksStock.Get(bookID);

        /// <summary>
        /// Adicionar um BookStock e atualizar a data do estoque. 
        /// </summary>
        /// <param name="newBookStock">Informar o novo BookStock</param>
        public BookStock Post(BookStock newBookStock)
        {
            _booksStockDataBase.BooksStock.Add(newBookStock);
            return newBookStock;
        }

        /// <summary>
        /// Atualizar um BookStock
        /// </summary>
        /// <param name="bookStockUpdated">Informar o BookStock atualizado</param>
        public BookStock Put(BookStock bookStockUpdated)
        {
            _booksStockDataBase.BooksStock.Update(bookStockUpdated);
            return bookStockUpdated;
        }

        /// <summary>
        /// Excluir um BookStock
        /// </summary>
        /// <param name="bookID">Informar o id do BookStock</param>
        public void Delete(string bookID) => _booksStockDataBase.BooksStock.Delete(bookID);
    }
}
