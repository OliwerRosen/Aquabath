using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
  public class User
  {
    public int Id { get; set; }
    public string? FirstName { get; set; } = "";
    public string? LastName { get; set; } = "";
    public ICollection<Review>? Reviews { get; set; }
  }
}