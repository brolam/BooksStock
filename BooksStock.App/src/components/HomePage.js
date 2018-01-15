import React from 'react'
import PropTypes from 'prop-types'
import SearchBar from '../components/SearchBar'
import BookStockList from '../components/BookStockList'
import WaitProcessModal from '../components/WaitProcessModal'
import { newBookStock, deleteBookStock, requestBooksStock, searchBookStock } from '../store/actions'
import BookStockModal from '../components/BookStockModal'
import QuestionModal from '../components/QuestionModal'

function HomePage({
  booksStock,
  isShowWaitProcessModal = false,
  isNewBookStock = false,
  isEditBookStock = false,
  isDeleteBookStock = false,
  selectedBookStock = undefined,
  searchValeu = '',
  dispatch }) {
  const searchOneBookStock = function (bookStock, searchValue) {
    if (searchValue.length === 0) return true
    return bookStock.BookName.toLowerCase().includes(searchValue.toLowerCase())
  }
  return (
    <div className="app">
      <div className="main-page-header">
        <div className="main-page-header-title">
          <span />
          <h1>BooksStock</h1>
        </div>
      </div>
      <SearchBar
        placeholder="Search by book name"
        onSearch={value => dispatch(searchBookStock(value))}
      />
      <div className="main-page-content">
        <BookStockList
          booksStock={booksStock.filter(bookStock => searchOneBookStock(bookStock, searchValeu))}
          dispatch={dispatch}
        />
      </div>
      {
        isShowWaitProcessModal && (
          <WaitProcessModal
            message="Please wait while the information is updated."
          />
        )
      }
      {isNewBookStock && (<BookStockModal bookStock={{}} dispatch={dispatch} />)}
      {isEditBookStock && (<BookStockModal bookStock={selectedBookStock} dispatch={dispatch} />)}
      {isDeleteBookStock && (
        <QuestionModal
          message={"Confirmar a exclução?"}
          onYesAnswer={() => dispatch(deleteBookStock(selectedBookStock))}
          onNoAnswer={() => dispatch(requestBooksStock())}
          timeout={10000}
        />)}
      <div className="flat-button" onClick={() => dispatch(newBookStock())} >
        <a className="add">Add BookStock</a>
      </div>
    </div>
  )
}

HomePage.propTypes = {
  booksStock: PropTypes.array.isRequired,
}

export default HomePage