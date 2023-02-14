using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.DTOs;

namespace Server.Interface
{
  public interface IArticleCategoryRepository : ICommonDataRepository
  {
    public Task<List<GetArticleCategoryDTO>> ListAllCategoriesAsync();
  }
}