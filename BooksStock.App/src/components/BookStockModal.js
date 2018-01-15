import React from 'react'
import { parseReportValidityMethod } from './utils/FormReportValidity'
import { saveBookStock } from '../store/actions'
import { requestBooksStock} from '../store/actions'

let inputBookName
let inputStockQuantity

function BookStockModal(props) {
  const { bookStock , dispatch } = props
  function parseFields(e) {
    parseReportValidityMethod(inputBookName)
    parseReportValidityMethod(inputStockQuantity)
    if (inputBookName.reportValidity() && inputStockQuantity.reportValidity()) {
      const updatedBS =  getUpdateBookStock(bookStock, inputBookName.value, inputStockQuantity.value)
      dispatch(saveBookStock(updatedBS))
    }
  }

  return (
    <div id="bookStockModal" className="modal modal-open" >
      <div className="modal-dialog">
        <div className="modal-heard modal-post">
          <span onClick={ () =>  dispatch(requestBooksStock())} />
          <input
            ref={(input) => { inputBookName = input; }}
            type="text"
            placeholder="Book Nome"
            defaultValue={bookStock.BookName}
            autoFocus
            required
            minLength="10"
            maxLength="80"
          />
        </div>
        <div className="modal-content modal-post">
          <input
            ref={(input) => { inputStockQuantity = input }}
            type="number"
            placeholder="Estoque"
            defaultValue={bookStock.StockQuantity}
            required
          />
          <div className="modal-footer">
            <button className={"save-button"}
              onClick={parseFields}>Save
          </button>
          </div>
        </div>
      </div>
    </div>
  )
}

export function getUpdateBookStock(bookStock, bookName, stockQuantity) {
  return bookStock.BookID
    ? { ...bookStock, BookName: bookName, StockQuantity: stockQuantity }
    : { BookName: bookName, StockQuantity: stockQuantity }
}

export default BookStockModal