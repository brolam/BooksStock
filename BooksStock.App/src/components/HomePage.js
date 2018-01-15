import React from 'react'
import PropTypes from 'prop-types'
import SearchBar from '../components/SearchBar'
import BookStockList from '../components/BookStockList'
import WaitProcessModal from '../components/WaitProcessModal'
import { newBookStock } from '../store/actions'

import BookStockModal from '../components/BookStockModal'

function HomePage({
   booksStock,
  isShowWaitProcessModal = false,
  isNewBookStock = false,
  isEditBookStock = false,
  selectedBookStock = undefined,
  dispatch }) {
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
      />
      <div className="main-page-content">
        <BookStockList
          booksStock={booksStock}
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