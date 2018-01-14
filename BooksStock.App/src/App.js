import React, { Component } from 'react';
import { connect } from 'react-redux'
import './App.css';
import HomePage from './components/HomePage'
import { clearQuestionModalTimeout } from './components/QuestionModal'
import { requestBooksStock } from './store/actions'

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }

  componentDidMount() { 
    this.props.dispatchRequestBooksStock("BookName")
  }
  
  componentWillUpdate() {
    clearQuestionModalTimeout()
  }

  render() {
    return(<HomePage {...this.props} />)
  }
}

function mapStateToProps({ appProps }, ownProps) {
  return appProps;
}

function mapDispatchToProps(dispatch, ownProps) {
  return {  
    dispatchRequestBooksStock: (fieldAscendingOrder) =>{
      dispatch(requestBooksStock(fieldAscendingOrder))
    },
    onSearch: (value) => {
    }
  }
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(App)