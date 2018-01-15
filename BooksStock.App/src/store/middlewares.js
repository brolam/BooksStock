import { returnBooksStock } from './actions'
import BooksStockAPI from '../BooksStockAPI'

export const appMiddleware = store => next => action => {
  switch (action.type) {
    case 'REQUEST_BOOKS_STOCK': {
      const { fieldAscendingOrder } = store.getState().appProps
      BooksStockAPI.get(fieldAscendingOrder).then(booksStock => {
        store.dispatch(returnBooksStock(booksStock))
      })
      return next(action)
    }
    case 'SAVE_BOOK_STOCK': {
      const { booksStock } = store.getState().appProps
      const { bookStock } = action
      BooksStockAPI.post(bookStock).then(bookStockUpdated => {
        const booksStockWithoutBSUpdated = booksStock.filter(bookStock => bookStock.BookID !== bookStockUpdated.BookID)
        const booksStockUpdated = [bookStockUpdated, ...booksStockWithoutBSUpdated]
        store.dispatch(returnBooksStock(booksStockUpdated))
      })
      return next(action)
    }
    case 'DELETE_BOOK_STOCK': {
      const { booksStock } = store.getState().appProps
      const { bookStock } = action
      BooksStockAPI.delete(bookStock).then(() => {
        const booksStockWithoutBSDeleted = booksStock.filter(oneBookStock => oneBookStock.BookID !== bookStock.BookID)
        store.dispatch(returnBooksStock(booksStockWithoutBSDeleted))
      })
      return next(action)
    }
    default:
      return next(action)
  }
}