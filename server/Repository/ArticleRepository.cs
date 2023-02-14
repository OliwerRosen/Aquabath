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
using Server.Models;

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

    public async Task<List<ArticleInListDTO?>> ListArticlesByCategory(int categoryId)
    {
      List<ArticleInListDTO> ArticleList = new List<ArticleInListDTO>();
      List<Article> articles = new List<Article>();
      articles = await _context.Articles
        .Where(a => a.Category.Id == categoryId)
        //.ProjectTo<ArticleInListDTO>(_mapper.ConfigurationProvider)
        .ToListAsync();
      foreach (Article article in articles)
      {
        bool isInStock = await _context.ArticleItems
          .Where(i => ((i.Article.Id == article.Id) && (i.IsInStock == true)))
          .AnyAsync();
        var reviews = await _context.Reviews
          .Where(r => r.Article.Id == article.Id)
          .ToListAsync();
        int reviewsCount = reviews.Count();
        double totalRating = 0;
        foreach (Review review in reviews)
        {
          totalRating = totalRating + review.Rating;
        }
        double averageRating = 0;
        int averageRatingInt = 0;
        if (reviewsCount != 0)
        {
          averageRating = (totalRating * 10 / reviewsCount);
          double averageRatingDec = Convert.ToDouble(averageRating);
          if (averageRatingDec % 1 > 0)
          {
            averageRatingDec = averageRatingDec / 10;
            double lastDigit = (Math.Floor((averageRatingDec % (1)) * 10)) / 10;
            if (lastDigit > 0.6)
            {
              averageRatingDec = Math.Ceiling(averageRatingDec);
            }
            else if (lastDigit < 0.4)
            {
              averageRatingDec = Math.Floor(averageRatingDec);
            }
            else if (lastDigit >= 0.4 && lastDigit <= 0.6)
            {
              averageRatingDec = Math.Floor(averageRatingDec) + 0.5;
            }
            averageRatingDec = averageRatingDec * 10;
            averageRatingInt = Convert.ToInt32(averageRatingDec);
          }
        }
        ArticleInListDTO articleDTO = new ArticleInListDTO();
        articleDTO.Id = article.Id;
        articleDTO.Name = article.Name;
        articleDTO.Price = article.Price;
        articleDTO.Img1 = article.Img1;
        articleDTO.CategoryId = article.CategoryId;
        articleDTO.ReviewCount = reviewsCount;
        articleDTO.IsInStock = isInStock;
        articleDTO.AverageRating = averageRatingInt;
        ArticleList.Add(articleDTO);
      }
      return ArticleList;
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