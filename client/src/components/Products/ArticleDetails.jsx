import {React, useEffect, useState} from 'react'
import {useParams} from 'react-router-dom'
import axios from 'axios'

function ArticleDetails() {

  const[articleId, setArticleId] = useState()
  const[article, setArticle]= useState()
  const[articleItems, setArticleItems]= useState([])
  const {id} = useParams();
  // setArticleId(id);
  useEffect(() =>{
    axios
      .get(`https://localhost:7242/api/v1/article/${id}`)
      .then(res => {
        setArticle(res.data)
        console.log(id)
        console.log(res.data)
        console.log(typeof(article))
      })
      .catch(err => {
        console.log(err)
      })

    axios
      .get(`https://localhost:7242/api/v1/articleitem/article/${id}`)
      .then(res2 => {
        setArticleItems(res2.data)
        console.log(id)
        console.log(res2.data)
        console.log(typeof(article))
      })
      .catch(err => {
        console.log(err)
      })
  }, [id])
  // `Nr of items in stock:${article.articleItems.isInStock}`
  // console.log()
  if(article === undefined)
  {
    return null;
  }
  return (
    <div>
      <div className='ItemContainer'>
        <div className='ItemArticleId'>{article.id}</div>
        <div className='ItemDescription'>{article.description}</div>
        <div className='ItemName'>{article.name}</div>
        <div className='NrInStock'>´Number of items: {articleItems.length}´</div>
        <div className='ItemPrice'>{article.price}</div>
        <div className="ItemImgbox">
          <img src={article.img1} className="itemImage" />
        </div>
      </div>
    </div>
  )
}

export default ArticleDetails
