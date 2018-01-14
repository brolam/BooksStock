const api = "http://localhost:50579/"
let BooksStockAPI = {};
const fetchOption = (method) => ({
  method,
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
  }
})

BooksStockAPI.get = (fieldAscendingOrder) => {
  return fetch(`${api}api/BooksStock?fieldAscendingOrder=${fieldAscendingOrder}`, fetchOption('GET'))
    .then(res => res.json())
    .then(booksStock => booksStock)
}

export default BooksStockAPI;

