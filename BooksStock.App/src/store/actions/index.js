export function requestBooksStock(fieldAscendingOrder) {
  return {
    type: 'REQUEST_BOOKS_STOCK',
    fieldAscendingOrder
  }
}

export function returnBooksStock(booksStock) {
  return {
    type: 'RETURN_BOOKS_STOCK',
    booksStock
  }
}