using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Server.Data;
using Server.DTOs;
using Server.Interface;
using Microsoft.EntityFrameworkCore;

namespace Server.Repository
{
  public class ArticleRepository : IArticleRepository
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ArticleRepository(DataContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

    public async Task<List<GetArticleDTO>> ListArticlesByCategory(int categoryId)
    {
      return await _context.Articles
      .Where(a => a.Category.Id == categoryId)
      .ProjectTo<GetArticleDTO>(_mapper.ConfigurationProvider)
      .ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<GetArticleDTO?> GetArticleById(int articleId)
    {
      return await _context.Articles
      .Where(a => a.Id == articleId)
      .ProjectTo<GetArticleDTO>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync();
    }
  }
}