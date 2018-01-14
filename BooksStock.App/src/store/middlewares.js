import { returnBooksStock } from './actions'
import BooksStockAPI from '../BooksStockAPI'

export const appMiddleware = store => next => action => {
  switch (action.type) {
    case 'REQUEST_BOOKS_STOCK': {
      const { fieldAscendingOrder } = store.getState().appProps
      BooksStockAPI.get(fieldAscendingOrder).then( booksStock => {
          store.dispatch(returnBooksStock(booksStock))
      })
      return next(action)
    }
    default:
      return next(action)

  }
}