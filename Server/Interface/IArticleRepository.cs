using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.DTOs;

namespace Server.Interface
{
  public interface IArticleRepository
  {
    public Task<bool> SaveAllAsync();
    public Task<List<GetArticleDTO>> ListArticlesByCategory(int categoryId);
    public Task<GetArticleDTO?> GetArticleById(int articleId);
  }
}