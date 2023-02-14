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
  [Route("api/v1/articleitem")]
  public class ArticleItemsController : ControllerBase
  {
    private readonly IArticleItemRepository _articleItemRepo;
    public ArticleItemsController(IArticleItemRepository articleItemsRepo)
    {
      _articleItemRepo = articleItemsRepo;
    }

    [HttpGet("article/{articleId}")]
    public async Task<ActionResult<List<GetArticleItemDTO>>> GetArticleItemsByArticleId(int articleId)
    {
      return Ok(await _articleItemRepo.ListArticleItemsByArticleId(articleId));
    }
    [HttpGet("article/{articleId}/isinstock")]
    public async Task<ActionResult<List<GetArticleItemDTO>>> GetArticleItemsInStockByArticleId(int articleId)
    {
      return Ok(await _articleItemRepo.ListArticleItemsInStockByArticleId(articleId));
    }
  }
}