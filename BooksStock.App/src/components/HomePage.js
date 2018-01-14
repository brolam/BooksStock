import React from 'react'
import PropTypes from 'prop-types'
import SearchBar from '../components/SearchBar'
import BookStockList from '../components/BookStockList'
import WaitProcessModal from '../components/WaitProcessModal'

function HomePage({
  booksStock,
  isShowWaitProcessModal = false,
  }) {
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
       />
      </div>
      {
        isShowWaitProcessModal && (
          <WaitProcessModal
            message="Please wait while the information is updated."
          />
        )
      }
      <div className="flat-button" >
        <a className="add">Add BookStock</a>
      </div>
    </div>
  )
}

HomePage.propTypes = {
  booksStock: PropTypes.array.isRequired,
}

export default HomePage