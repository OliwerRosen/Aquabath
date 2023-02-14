using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTOs
{
  public class GetArticleItemDTO
  {
    public int Id { get; set; }
    public bool IsInStock { get; set; }
    public string DateSold { get; set; } = "";
    public string DateLeftStock { get; set; } = "";
    public string DateArrivedInStock { get; set; } = "";
    public int ArticleId { get; set; }
  }
}