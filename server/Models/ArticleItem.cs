using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
  public class ArticleItem
  {
    public int Id { get; set; }
    public bool IsInStock { get; set; }
    public string DateSold { get; set; } = "";
    public string DateLeftStock { get; set; } = "";
    public string DateArrivedInStock { get; set; } = "";
    public Article Article { get; set; } = new Article();
  }
}