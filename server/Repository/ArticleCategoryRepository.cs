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
  public class ArticleCategoryRepository : IArticleCategoryRepository
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ArticleCategoryRepository(DataContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<GetArticleCategoryDTO>> ListAllCategoriesAsync()
    {
      return await _context.ArticleCategories.ProjectTo<GetArticleCategoryDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }
  }
}