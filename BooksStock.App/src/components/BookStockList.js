import React from 'react'
import PropTypes from 'prop-types'
import OrderOptions from '../components/OrderOptions'
import BookStockItem from '../components/BookStockItem'
import { changeFieldAscendingOrder, requestBooksStock } from '../store/actions/index';

function BookStockList({ booksStock, dispatch }) {
  return (
    <div className="booksStock">
      <div className="booksStock-title">
        <span>Books</span>
        <OrderOptions
          onChangeOrder={field => {
            dispatch(changeFieldAscendingOrder(field))
            dispatch(requestBooksStock())
          }}
        />
      </div>
      <div className="booksStock-list">
        {booksStock.map(bookStock => {
          return (
            <BookStockItem
              key={bookStock.BookID}
              bookStock={bookStock}
              dispatch={dispatch}
            />
          )
        })}
      </div>
    </div>
  )
}

BookStockList.propTypes = {
  booksStock: PropTypes.array.isRequired,
}

export default BookStockList
