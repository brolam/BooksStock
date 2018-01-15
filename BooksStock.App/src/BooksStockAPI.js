const api = "http://localhost:50579/"
let BooksStockAPI = {};
const fetchOption = (method) => ({
  method,
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
  }
})

function encodeData(data) {
  return Object.keys(data).map((key) => {
    return [key, data[key]].map(encodeURIComponent).join("=");
  }).join("&");
}

BooksStockAPI.get = (fieldAscendingOrder) =>
  fetch(`${api}api/BooksStock?fieldAscendingOrder=${fieldAscendingOrder}`, fetchOption('GET'))
    .then(res => res.json())

BooksStockAPI.save = (bookStock) =>
  fetch(`${api}api/BooksStock?${encodeData(bookStock)}`,
    bookStock.BookID
      ? fetchOption('PUT')
      : fetchOption('POST')
  ).then(res => res.json())

BooksStockAPI.delete = (bookStock) =>
  fetch(`${api}api/BooksStock?bookID=${bookStock.BookID}`, fetchOption('DELETE'))

export default BooksStockAPI;