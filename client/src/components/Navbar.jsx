import { NavLink } from 'react-router-dom';

function Navbar() {
  return(
    <nav className="navbar">
      <h1 className="logo">
        <span className="text-primary">
        <i class="fa-solid fa-soap"></i> Bathroom
        </span> AB
      </h1>
      <ul className="navbar__list">
        <li>
        <NavLink  to='/Products'>Products</NavLink>
        <NavLink to='/Economy'>Economy</NavLink>
        <NavLink to='/Stockmanagement'>Stock Management</NavLink>
        <NavLink to='/User/Register'>Register</NavLink>
        <NavLink to='/User/Login'>Login</NavLink>
        </li>
      </ul>
    </nav>
  );
}

export default Navbar;