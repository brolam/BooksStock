import React from 'react'

function OrderOptions({
  selectedValue = 'BookName',
  onChangeOrder = order => { } }) {
  return (
    <div className="order-options">
      <select
        onChange={e => onChangeOrder(e.target.value)}
        defaultValue={selectedValue}>
        <option value="BookName" >Nome do Livro</option>
        <option value="StockQuantity" >Quantidade do Estoque</option>
      </select>
    </div>
  )
}

export default OrderOptions