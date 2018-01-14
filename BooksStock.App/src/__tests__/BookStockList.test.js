import React from 'react'
import ReactDOM from 'react-dom'
import renderer from 'react-test-renderer'
import BookStockList from '../components/BookStockList'

test('render without error', () => {
  ReactDOM.render(
    <BookStockList
    booksStock={booksStock}
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