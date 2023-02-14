using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
  public static class ReviewGenerator
  {
    public static async Task<Review> reviewCreator(DataContext context, Article article)
    {
      Random rand = new Random();
      int rating;
      string comment = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorem eius reiciendis asperiores perferendis ducimus eveniet qui doloribus assumenda impedit? Asperiores at dicta magnam molestias deserunt minima? Voluptatum repudiandae nesciunt natus.";
      //User randomUser;
      int userCount = await context.Users.CountAsync();
      int randomUserIndex = rand.Next(userCount) + 1;
      User randomUser = await context.Users
        .Where(u => u.Id == randomUserIndex)
        .SingleOrDefaultAsync();
      rating = rand.Next(6);
      Review review = new Review()
      {
        Rating = rating,
        Comment = comment,
        User = randomUser,
        Article = article
      };
      return review;
    }
  }
}