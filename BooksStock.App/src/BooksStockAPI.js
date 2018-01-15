const api = "http://localhost:50579/"
let BooksStockAPI = {};
const fetchOption = (method) => ({
  method,
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
  },
})

BooksStockAPI.get = (fieldAscendingOrder) =>
  fetch(`${api}api/BooksStock?fieldAscendingOrder=${fieldAscendingOrder}`, fetchOption('OPTIONS'))
    .then(res => res.json())

BooksStockAPI.post = (bookStock) =>
  fetch(`${api}api/BooksStock?bookName=${bookStock.BookName}&stockQuantity=${bookStock.StockQuantity}`, fetchOption('OPTIONS'))
    .then(res => res.json())

BooksStockAPI.delete = (bookStock) =>
  fetch(`${api}api/BooksStock?bookID=${bookStock.BookID}`, fetchOption('GET'))

export default BooksStockAPI;

