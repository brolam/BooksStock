export function requestBooksStock() {
  return {
    type: 'REQUEST_BOOKS_STOCK'
  }
}

export function returnBooksStock(booksStock) {
  return {
    type: 'RETURN_BOOKS_STOCK',
    booksStock
  }
}

export function newBookStock() {
  return {
    type: 'NEW_BOOK_STOCK'
  }
}

export function editBookStock(bookStock) {
  return {
    type: 'EDIT_BOOK_STOCK',
    bookStock
  }
}

export function saveBookStock(bookStock) {
  return {
    type: 'SAVE_BOOK_STOCK',
    bookStock
  }
}