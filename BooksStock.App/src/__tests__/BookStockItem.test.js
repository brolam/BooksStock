import React from 'react'
import ReactDOM from 'react-dom'
import renderer from 'react-test-renderer'
import { mount } from 'enzyme';
import BookStockItem from '../components/BookStockItem'

test('render without error', () => {
  ReactDOM.render(
    <BookStockItem
      bookStock={bookStock}
    />, document.createElement('div')
  );
})

const bookStock = {
  BookID: "5a5b297e1044f119a8912c4f",
  BookName: "1 BookStock",
  StockQuantity: 10,
  StockUpdated: "2018-01-14T09:57:18.217Z"
}