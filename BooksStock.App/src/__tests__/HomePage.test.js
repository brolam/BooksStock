import React from 'react'
import ReactDOM from 'react-dom'
import renderer from 'react-test-renderer'
import { mount } from 'enzyme';
import HomePage from '../components/HomePage'

test('render without error', () => {
  ReactDOM.render(
    <HomePage
      booksStock={booksStock}
      isShowWaitProcessModal={false}
    />, document.createElement('div')
  );
})

test('showWaitProcessModal', () => {
  ReactDOM.render(
    <HomePage
      booksStock={booksStock}
      isShowWaitProcessModal={true}
    />, document.createElement('div')
  );
})

test('newBookStock', () => {
  ReactDOM.render(
    <HomePage
      booksStock={booksStock}
      isNewBookStock={true}
    />, document.createElement('div')
  );
})

test('editBookStock', () => {
  ReactDOM.render(
    <HomePage
      booksStock={booksStock}
      isEditBookStock={true}
      selectedBookStock={booksStock[0]}
    />, document.createElement('div')
  );
})

test('deleteBookStock', () => {
  ReactDOM.render(
    <HomePage
      booksStock={booksStock}
      isDeleteBookStock={true}
      selectedBookStock={booksStock[0]}
    />, document.createElement('div')
  );
})

test('searchBookStock', () => {
  ReactDOM.render(
    <HomePage
      booksStock={booksStock}
      searchValeu={"1 BookStock"}
    />, document.createElement('div')
  );
})

const booksStock = [
  {
    BookID: "1a5b297e1044f119a8912c4f",
    BookName: "1 BookStock",
    StockQuantity: 10,
    StockUpdated: "2018-01-14T09:57:18.217Z"
  },
  {
    BookID: "2a5b297e1044f119a8912c4f",
    BookName: "1 BookStock",
    StockQuantity: 10,
    StockUpdated: "2018-01-14T09:57:18.217Z"
  }]