import React from 'react'
import NavbarItem from './NavbarItem';
import '../../css/products.css'
//import categories from '../../testjsondata/categories.json'
import { NavLink, Outlet } from 'react-router-dom';
import { useEffect, useState } from 'react';
import axios from 'axios';

function Products(props) {
  const {categories} = props;
  // const [categories, setCategories] = useState([])

  // useEffect(() => {
  //   axios.get('https://localhost:7242/api/v1/articleCategory/list')
  //     .then(response => {
  //         console.log(response)
  //         setCategories(response.data)
  //     })
  //     .catch(error => {
  //       console.log(error)
  //     })
  // }, [])

  return (
      <div className = "products__main">
        <div className = "emptySpaceLeft"></div>
        <div className = "mainContent"> 
          <div className="categories">
            <nav className="categoryLinks">
              <NavLink className="categoryLink" to={`/Products/`} style={({isActive}) => { return {backgroundColor: isActive ? "black" : null}}}>Index</NavLink>
              {categories.map(category => (
                <NavbarItem key ={category.id} name={category.name} id={category.id}/>
              ))}
            </nav>
          </div>
          <div className="categoryDisplay">
            <Outlet />
          </div>
        </div>
        <div className = "emptySpaceRight"></div>
      </div>
  )
}

export default Products
