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
  [Route("api/v1/article")]
  public class ArticlesController : ControllerBase
  {
    private readonly IArticleRepository _articleRepo;
    public ArticlesController(IArticleRepository articleTypeRepo)
    {
      _articleRepo = articleTypeRepo;
    }
    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<List<GetArticleDTO>>> GetCourseByCategory(int categoryId)
    {
      return Ok(await _articleRepo.ListArticlesByCategory(categoryId));
    }
    [HttpGet("{articleId}")]
    public async Task<ActionResult<GetArticleDTO>> GetArticleById(int articleId)
    {
      return Ok(await _articleRepo.GetArticleById(articleId));
    }
  }
}