import {React, useState, useEffect, useParams} from 'react'
import {useNavigate} from 'react-router-dom'
import '../../css/products.css'
import axios from 'axios'

function Article(props) {
  const {articleObject, categoryName} = props
  const navigate = useNavigate();
  //const [article, setArticle] = useState({})
  const [articleItems, setArticleItems] = useState([])
  //setArticle(articleObject);
  const handleClick = () => {
    navigate(`../${categoryName}/${articleObject.id}`)
  }
  useEffect(() =>{
  axios
      .get(`https://localhost:7242/api/v1/articleitem/article/${articleObject.id}`)
      .then(res => {
        //setArticleItems(res.data)
        console.log()
        console.log(`articleItems is: ${res.data}`)
      })
      .catch(err => {
        console.log(err)
      })
  }, [articleObject])

  return (
    <div className={`ItemContainer-${articleObject.id} ItemContainer`} value={articleObject.id} onClick={handleClick}>
      <div className='ItemName'>{articleObject.name}</div>
      {/* <div className='NrInStock'>{articleItems.length}</div> */}
      <div className='ItemPrice'>{articleObject.price}:-</div>
      <div className="ItemImgbox">
        <img src={articleObject.img1} className="ItemImage" />
      </div>
    </div>
  )
}

export default Article
