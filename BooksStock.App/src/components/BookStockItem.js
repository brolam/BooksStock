import React from 'react'
import PropTypes from 'prop-types'
import Moment from 'moment';
import { editBookStock } from '../store/actions'

function BookStockItem(props) {
  const { bookStock, dispatch } = props
  return (
    <div className="bookStock" onClick={props.onSelected}>
      <div className="bookStock-header">
        <div className="bookStock-name">
          {bookStock.BookName}
        </div>
        <div className="bookStock-updated">
          <span className="published">{Moment(bookStock.StockUpdated).from(new Date())}</span>
        </div>
      </div>
      <div className="bookStock-quantity">Estoque {bookStock.StockQuantity}</div>
      <div className="bookStock-footer">
        <button className="edit-button"
          onClick={e => dispatch(editBookStock(bookStock))} >Edit</button>
        <button className="delete-button"
          onClick={e => {
            e.stopPropagation()
          }
          }>Delete</button>
      </div>
    </div>
  )
}

BookStockItem.propTypes = {
  bookStock: PropTypes.shape({
    BookID: PropTypes.string.isRequired,
    BookName: PropTypes.string.isRequired,
    StockQuantity: PropTypes.number.isRequired,
    StockUpdated: PropTypes.string.isRequired,
  })
}

export default BookStockItem