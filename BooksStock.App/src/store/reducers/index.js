import { combineReducers } from 'redux'

const HOME_INITIAL_STATE = {
  searchValeu: '',
  booksStock: [],
  fieldAscendingOrder: 'BookName',
  isShowWaitProcessModal: false,
  isNewBookStock: false,
  isEditBookStock: false,
  isDeleteBookStock: false,
  selectedBookStock: undefined
};

function appProps(state = HOME_INITIAL_STATE, action) {
  switch (action.type) {
    case 'REQUEST_BOOKS_STOCK': {
      const { fieldAscendingOrder } = action
      return { ...state, fieldAscendingOrder, isShowWaitProcessModal: true }
    }
    case 'RETURN_BOOKS_STOCK': {
      const { booksStock } = action
      return {
        ...state,
        booksStock,
        isShowWaitProcessModal: false,
        isNewBookStock: false,
        isEditBookStock: false,
        isDeleteBookStock: false,
        selectedBookStock: undefined
      }
    }
    case 'NEW_BOOK_STOCK': {
      return { ...state, isNewBookStock: true }
    }
    case 'EDIT_BOOK_STOCK': {
      const { bookStock } = action
      return { ...state, isEditBookStock: true, selectedBookStock: bookStock }
    }
    case 'REQUEST_DELETE_BOOK_STOCK': {
      const { bookStock } = action
      return { ...state, isDeleteBookStock: true, selectedBookStock: bookStock }
    }
    case 'SEARCH_BOOK_STOCK': {
      const { searchValeu } = action
      return { ...state, searchValeu }
    }
    default:
      return state
  }
}

export default combineReducers({ appProps })