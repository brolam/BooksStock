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

export function requestDeleteBookStock(bookStock) {
  return {
    type: 'REQUEST_DELETE_BOOK_STOCK',
    bookStock
  }
}

export function deleteBookStock(bookStock) {
  return {
    type: 'DELETE_BOOK_STOCK',
    bookStock
  }
}

export function saveBookStock(bookStock) {
  return {
    type: 'SAVE_BOOK_STOCK',
    bookStock
  }
}

export function searchBookStock(searchValeu) {
  return {
    type: 'SEARCH_BOOK_STOCK',
    searchValeu
  }
}

export function changeFieldAscendingOrder(field) {
  return {
    type: 'CHANGE_FIELD_ASCENDING_ORDER',
    field
  }
}