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
      await SeedUsers(context, services);
      await SeedArticles(context, services);
    }

    private static async Task SeedUsers(DataContext context, System.IServiceProvider services)
    {
      int adminUsersCount = 1;
      int stockManagerUsersCount = 3;
      int customerUsersCount = 10;
      Random rand = new Random();
      List<User> users = new List<User>();
      string[] fNames = { "Kalle", "Stina", "Pelle", "Maja", "Olle" };
      string[] lNames = { "Pettersson", "Almgren", "Svansson", "Fredriksson", "Grenberg" };

      for (int i = 0; i < customerUsersCount; i++)
      {
        string firstName = fNames.ElementAt(rand.Next(fNames.Count()));
        string lastName = lNames.ElementAt(rand.Next(lNames.Count()));
        User user = new User()
        {
          FirstName = firstName,
          LastName = lastName,
        };
        await context.Users.AddAsync(user);
      }
      await context.SaveChangesAsync();
    }

    private static async Task SeedArticles(DataContext context, System.IServiceProvider services)
    {
      Random rand = new Random();
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
            Article article = ArticleGenerator.articleCreator(context, catadded, 1, 5, 3);
            if (article is not null)
            {
              int hasReviews = rand.Next(50);
              if (hasReviews != 1)
              {
                int nrOfReviews = rand.Next(20) + 1;
                for (int j = 0; j < nrOfReviews; j++)
                {
                  Review review = new Review();
                  review = await ReviewGenerator.reviewCreator(context, article);
                  await context.Reviews.AddAsync(review);
                }
              }
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
    }
  }
}