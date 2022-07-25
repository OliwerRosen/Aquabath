import React from 'react'
import { NavLink } from 'react-router-dom';

function NavbarItem(props) {
  const {name, id} = props;
  return (
      <NavLink className="categoryLink" to={`/Products/${name}`} style={({isActive}) => { return {backgroundColor: isActive ? "black" : null}}}>{name}</NavLink>
  )
}

export default NavbarItem
