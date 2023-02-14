using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interface
{
  public interface ICommonDataRepository
  {
    public Task<bool> SaveAllAsync();
  }
}