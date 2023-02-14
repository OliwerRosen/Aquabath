using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTOs
{
  public class ArticleInListDTO
  {
    public int Id { get; set; }
    public string? Name { get; set; } = "";
    public int Price { get; set; }
    public string? Img1 { get; set; } = "";
    public int CategoryId { get; set; }
    public int ReviewCount { get; set; }
    public bool IsInStock { get; set; }
    public int AverageRating { get; set; }

  }
}