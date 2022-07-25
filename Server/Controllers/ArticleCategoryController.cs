using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DTOs;
using Server.Interface;

namespace Server.Controllers
{
  [ApiController]
  [Route("api/v1/articleCategory")]
  public class ArticleCategoryController : ControllerBase
  {
    private readonly IArticleCategoryRepository _articleCategoryRepo;
    public ArticleCategoryController(IArticleCategoryRepository articleCategoryRepository)
    {
      _articleCategoryRepo = articleCategoryRepository;
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<GetArticleCategoryDTO>>> ListAllArticleCategories()
    {
      return Ok(await _articleCategoryRepo.ListAllCategoriesAsync());
    }
  }
}