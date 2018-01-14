const api = "http://localhost:50579/"
let BooksStockAPI = {};
const fetchOption = (method) => ({
  method: 'OPTIONS',
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
  },
})

BooksStockAPI.get = (fieldAscendingOrder) =>
  fetch(`${api}api/BooksStock?fieldAscendingOrder=${fieldAscendingOrder}`, fetchOption('GET'))
    .then(res => res.json())

BooksStockAPI.post = (bookStock) =>
  fetch(`${api}api/BooksStock?bookName=${bookStock.BookName}&stockQuantity=${bookStock.StockQuantity}`, fetchOption('GET'))
    .then(res => res.json())

export default BooksStockAPI;

