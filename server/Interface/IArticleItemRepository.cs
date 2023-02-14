using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.DTOs;

namespace Server.Interface
{
  public interface IArticleItemRepository : ICommonDataRepository
  {
    public Task<List<GetArticleItemDTO>> ListArticleItemsByArticleId(int ArticleId);
    public Task<GetArticleItemDTO?> GetArticleItemById(int id);
    public Task<List<GetArticleItemDTO?>> ListArticleItemsInStockByArticleId(int articleId);
  }
}