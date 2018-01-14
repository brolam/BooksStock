import React from 'react'
import PropTypes from 'prop-types'
import OrderOptions from '../components/OrderOptions'
import BookStockItem from '../components/BookStockItem'

function BookStockList({booksStock}) {
  return (
    <div className="booksStock">
      <div className="booksStock-title">
        <span>Books</span>
        <OrderOptions />
      </div>
      <div className="booksStock-list">
        {booksStock.map( bookStock => {
          return (
            <BookStockItem
              key={bookStock.BookID}
              bookStock={bookStock}
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
