import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import { Navigate } from 'react-router-dom';
import {React, useState, useEffect} from 'react';
import axios from 'axios';
import Navbar from './components/Navbar';
import './css/main.css'
import Products from './components/Products/Products';
import Toilets from './components/Products/Toilets';
import Showers from './components/Products/Showers';
import Sinks from './components/Products/Sinks';
import Soaps from './components/Products/Soaps';
import CategoryIndex from './components/Products/CategoryIndex';
import ItemDetails from './components/Products/ArticleDetails';
import ArticleListDisplay from './components/Products/ArticleListDisplay';

function App() {
  const [categories, setCategories] = useState([])

  useEffect(() => {
    axios.get('https://localhost:7242/api/v1/articleCategory/list')
      .then(response => {
          console.log(response)
          setCategories(response.data)
      })
      .catch(error => {
        console.log(error)
      })
  }, [])

  return (
    <Router>
      <Navbar />
      <main>
        <div className="App">
        <Routes>
          <Route path = '/' element={<Navigate to ="/Products" />} />
          <Route path = 'Products' element={<Products categories={categories} />} >
            <Route index element ={<CategoryIndex />} />
            {categories.map(category => (
              <Route path = {`${category.name}`} key={category.id} element={<ArticleListDisplay categoryId={category.id} categoryName={category.name} />} ></Route>
              ))}
            {categories.map(category => (  
              <Route path = {`${category.name}/:id`} key={`${category.id}/:id`} element={<ItemDetails />} />
              ))}
          </Route>
        </Routes>
        </div>
      </main>
    </Router>
  );
}

export default App;
