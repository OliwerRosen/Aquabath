import React from 'react'
import ShowerData from '../../testjsondata/showers.json'
import Item from './Article'

function Showers() {
  return (
    <>
      {ShowerData.map((shower) => (
        <Item key ={shower.ArticleId} ItemObject={shower}/>
        ))} 
    </>
  )
}

export default Showers
