import {React, useState, useEffect } from 'react'
import axios from 'axios';
//import ShowerData from '../../testjsondata/showers.json'
import Article from './Article'

function ArticleListDisplay(props) {
  const {categoryId, categoryName} = props;
  const [articles, setArticles] = useState([])
  const [category, setCategory] = useState()
   useEffect(() => {
    axios.get(`https://localhost:7242/api/v1/article/category/${categoryId}`)
      .then(response => {
          console.log(response)
          setArticles(response.data)
      })
      .catch(error => {
        console.log(error)
      })
      
  }, [categoryId])
  return (
    <>
      {articles.map((article) => (
        <Article key={article.id} articleObject={article} categoryName={categoryName}/>
        ))} 
    </>
  )
}

export default ArticleListDisplay
