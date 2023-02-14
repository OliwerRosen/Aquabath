using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
  public class Article
  {

    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Price { get; set; }
    public string Description { get; set; } = "";
    public string Img1 { get; set; } = "";
    public string Img2 { get; set; } = "";
    public string Img3 { get; set; } = "";
    public int CategoryId { get; set; }
    public ArticleCategory Category { get; set; } = new ArticleCategory();
    public ICollection<ArticleItem>? ArticleItems { get; set; }
    public ICollection<Review>? Reviews { get; set; }

  }
}