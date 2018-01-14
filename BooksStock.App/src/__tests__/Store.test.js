import {
 requestBooksStock,
 returnBooksStock
} from '../store/actions'
import store from '../store'

const HOME_INITIAL_STATE = {
  searchValeu : undefined,
  booksStock: [],
  fieldAscendingOrder: 'BookName',
  isShowWaitProcessModal: false,
  isEditBookStock: false,
  isDeleteBookStock: false,
  selectedBookStoc:  undefined
};

test('home store initial state', () => {
  store.dispatch({ type: '' });
  const { appProps } = store.getState()
  expect(HOME_INITIAL_STATE).toEqual(appProps);
})
