using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
  public static class SeedData
  {
    public static async Task Initialize(DataContext context, System.IServiceProvider services)
    {
      //   using (var context = new DataContext(
      //       serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
      //   {
      // await context.Database.EnsureDeletedAsync();

      int articlesInCategory = 20;
      List<String> categories = new List<string>();
      string[] cats = { "Showers", "Sinks", "Toilets", "Soaps", "Faucets", "Mirrors" };
      categories.AddRange(cats);
      var logger = services.GetRequiredService<ILogger<Program>>();

      foreach (var cat in categories)
      {
        var newcat = new ArticleCategory
        {
          Name = cat,
        };
        await context.ArticleCategories.AddAsync(newcat);
        await context.SaveChangesAsync();
        int id = newcat.Id;
        var catadded = await context.ArticleCategories.FindAsync(id);
        if (catadded is not null)
        {
          for (int i = 0; i < articlesInCategory; i++)
          {
            Article article = ArticleGenerator.articleCreator(catadded, 1, 5, 3);
            if (article is not null)
            {
              await context.Articles.AddAsync(article);
              var articleItems = ArticleItemGenerator.createArticleItems(article);
              await context.ArticleItems.AddRangeAsync(articleItems);
            }
            else
            {
              var ex = new Exception();
              logger.LogError(ex, "Ett fel inträffade när migrering utfördes");
            }
          }
        }
        else
        {
          var ex = new Exception();
          logger.LogError(ex, "Ett fel inträffade med att skapa ID");
        }
      }

      //   }
    }
  }
}