using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTOs
{
  public class GetArticleCategoryDTO
  {
    public int Id { get; set; }
    public string Name { get; set; } = "";
  }
}