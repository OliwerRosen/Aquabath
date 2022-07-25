using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.DTOs;
using Server.Models;

namespace Server.Automapper
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      //ArticleCategory
      CreateMap<ArticleCategory, GetArticleCategoryDTO>();
      CreateMap<Article, GetArticleDTO>();
      CreateMap<ArticleItem, GetArticleItemDTO>();
    }
  }
}