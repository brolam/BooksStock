import React from 'react'
import ReactDOM from 'react-dom'
import renderer from 'react-test-renderer'
import App from '../App';
import { Provider } from 'react-redux'
import store from '../store'
import { mount } from 'enzyme'

test('render without error', () => {
  ReactDOM.render(
    <Provider store={store}>
      <App />
    </Provider>
    , document.createElement('div')
  );
})

test('new BookStock', () => {
  const app = mount(<Provider store={store}><App /></Provider>)
  const newBookStockButton = app.find('.flat-button');
  newBookStockButton.simulate('click');
  const { inputBookName, inputStockQuantity, buttonSave } = getBookStockModalInputs(app)
  inputBookName.instance().value = '3 BookStock'
  inputStockQuantity.instance().value = 100
  buttonSave.simulate('click')
  const bookStockInserted = booksStock[0]
  expect(bookStockInserted.BookName).toBe('3 BookStock')
  expect(bookStockInserted.StockQuantity).toBe(100)
})

test('edit BookStock', () => {
  const app = mount(<Provider store={store}><App /></Provider>)
  const editButton = app.find('button [className="edit-button"]').first().simulate('click')
  editButton.simulate('click')
  const { inputBookName, inputStockQuantity, buttonSave } = getBookStockModalInputs(app)
  inputBookName.instance().value = '3 BookStock Updated'
  inputStockQuantity.instance().value = 200
  buttonSave.simulate('click')
  const bookStockUpdated = booksStock[0]
  expect(bookStockUpdated.BookName).toBe('3 BookStock Updated')
  expect(bookStockUpdated.StockQuantity).toBe(200)
})

test('delete BookStock', () => {
  const app = mount(<Provider store={store}><App /></Provider>)
  const deleteButton = app.find('button [className="delete-button"]').first().simulate('click')
  deleteButton.simulate('click')
  const yesButton = app.find('a [className="yes"]')
  yesButton.simulate('click')
  expect(booksStock.length).toBe(2)
})

function getBookStockModalInputs(app) {
  const inputBookName = app.find('div [className="modal-heard modal-post"] input')
  const inputStockQuantity = app.find('div [className="modal-content modal-post"] input')
  return {
    inputBookName,
    inputStockQuantity,
    buttonSave: app.find('.save-button')
  }
}

//test dummy
var booksStock = [
  {
    BookID: "1a5b297e1044f119a8912c4f",
    BookName: "1 BookStock",
    StockQuantity: 10,
    StockUpdated: "2018-01-14T09:57:18.217Z"
  },
  {
    BookID: "2a5b297e1044f119a8912c4f",
    BookName: "2 BookStock",
    StockQuantity: 10,
    StockUpdated: "2018-01-14T09:57:18.217Z"
  }]

//Mock fetch
global.fetch = (url, body) => new Promise(function (then) {
  if (body.method === 'GET') then({ json: () => booksStock })
  if (body.method === 'POST') {
    const newBookStock = {
      BookID: '3',
      StockUpdated: "2018-01-14T09:57:18.217Z",
      ...getBookStockByUrl(url)
    }
    booksStock = [newBookStock, ...booksStock]
    then({ json: () => booksStock[0] })
  }

  if (body.method === 'PUT') {
    const updatedBookStock = { ...getBookStockByUrl(url) }
    booksStock[0] = updatedBookStock
    then({ json: () => booksStock[0] })
  }

  if (body.method === 'DELETE') {
    booksStock.splice(0, 1)
    then({ json: () => { } })
  }
})

function getBookStockByUrl(url) {
  let urlRoot = url.split('?')
  let paramArr = urlRoot[1].split('&');
  let bookStock = {};
  paramArr.forEach(e => {
    let param = e.split('=');
    bookStock[param[0]] = decodeURIComponent(param[1]);
  });
  bookStock.StockQuantity = parseInt(bookStock.StockQuantity)
  return bookStock;
}