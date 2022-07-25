using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
  public class Stock
  {
    public int Id { get; set; }
    public string Adress { get; set; } = "";
    public string DateBuilt { get; set; } = "";
  }
}