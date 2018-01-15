import {
  requestBooksStock,
  returnBooksStock
} from '../store/actions'
import store from '../store'

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

test('home store initial state', () => {
  store.dispatch({ type: '' });
  const { appProps } = store.getState()
  expect(HOME_INITIAL_STATE).toEqual(appProps);
})
