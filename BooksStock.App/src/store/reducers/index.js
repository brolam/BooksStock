import { combineReducers } from 'redux'

const HOME_INITIAL_STATE = {
  searchValeu : undefined,
  booksStock: [],
  fieldAscendingOrder: 'BookName',
  isShowWaitProcessModal: false,
  isEditBookStock: false,
  isDeleteBookStock: false,
  selectedBookStoc:  undefined
};

function appProps(state = HOME_INITIAL_STATE, action) {
  switch (action.type) {
    case 'REQUEST_BOOKS_STOCK': {
      const { fieldAscendingOrder } = action
      return { ...state, fieldAscendingOrder, isShowWaitProcessModal: true }
    }
    case 'RETURN_BOOKS_STOCK': {
      const { booksStock } = action
      return { ...state, booksStock, isShowWaitProcessModal: false }
    }
    default:
      return state
  }
}

export default combineReducers({ appProps })