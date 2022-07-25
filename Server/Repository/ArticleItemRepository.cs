using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.DTOs;
using Server.Interface;

namespace Server.Repository
{
  public class ArticleItemRepository : IArticleItemRepository
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ArticleItemRepository(DataContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }
    public async Task<GetArticleItemDTO?> GetArticleItemById(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<List<GetArticleItemDTO>> ListArticleItemsByArticleId(int ArticleId)
    {
      return await _context.ArticleItems.Where(i => i.Article.Id == ArticleId)
        .ProjectTo<GetArticleItemDTO>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }

    public Task<bool> SaveAllAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<List<GetArticleItemDTO?>> ListArticleItemsInStockByArticleId(int articleId)
    {
      return await _context.ArticleItems.Where(i => ((i.Article.Id == articleId) && (i.IsInStock == true)))
        .ProjectTo<GetArticleItemDTO>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }
  }
}
}