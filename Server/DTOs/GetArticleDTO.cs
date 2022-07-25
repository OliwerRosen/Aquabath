using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTOs
{
  public class GetArticleDTO
  {
    public int Id { get; set; }
    public string? Name { get; set; } = "";
    public int Price { get; set; }
    public string? Description { get; set; } = "";
    public string? Img1 { get; set; } = "";
    public string? Img2 { get; set; } = "";
    public string? Img3 { get; set; } = "";
    public int CategoryId { get; set; }
  }
}