using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Data
{
  public static class ArticleGenerator
  {
    public static int randomPriceGenerator(int minInt, int maxInt, int zeros)
    {
      Random rand = new Random();
      int interval = maxInt - minInt;
      int extraZeros = System.Convert.ToInt32(Math.Pow(10, zeros));
      int randomHundred = rand.Next(100);
      int price = (rand.Next(interval) + minInt) * extraZeros + randomHundred * 10;
      return price;
    }
    public static string randomWordSelector(string[] words)
    {
      Random rand = new Random();
      var wordIndex = rand.Next(words.Length);
      return words[wordIndex];
    }
    public static Article articleCreator(ArticleCategory category, int minInt, int maxInt, int zeros)
    {
      string[] ShowerNouns = { "shower" };
      string[] ShowerPrefix = { "Stylish", "Fashionable", "Modern", "Excellent", "Popular", "Sturdy" };
      string[] ShowerSuffix = { "Form", "Lux", "Select", "Legato" };
      string[] ShowerIMGs = { "https://i.imgur.com/27xN9Xj.jpg", "https://i.imgur.com/WI7VCpa.jpg", "https://i.imgur.com/anEUtTH.jpg", "https://i.imgur.com/IbeXJKn.jpg", "https://i.imgur.com/SNnyyCo.jpg", "https://i.imgur.com/gbVMTza.jpg", "https://i.imgur.com/Je1lyDe.jpg", "https://i.imgur.com/evHKokg.jpg", "https://i.imgur.com/FlSGZ29.jpg", "https://i.imgur.com/anBEuMq.jpg" };
      string lorem = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Praesentium quibusdam porro dolor fuga cupiditate aspernatur voluptatibus architecto aut unde eligendi? Inventore unde obcaecati reprehenderit quas placeat tempore aut delectus cumque iure repudiandae est, molestiae accusantium modi dolorem nulla eius sapiente.";


      var catName = category.Name.ToLower();
      var noun = "wrong";
      var pre = "wrong";
      var suf = "wrong";
      var IMG1 = "https://images.unsplash.com/photo-1596180744691-d19a1b90b53c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80";
      var IMG2 = "https://i.imgur.com/ZQ4osZ6.jpg";
      var IMG3 = "https://i.imgur.com/ZQ4osZ6.jpg";

      if (catName is null)
      {
        Article articlenull = new Article { };
        return articlenull;
      }
      if (catName == "showers")
      {
        noun = randomWordSelector(ShowerNouns);
        pre = randomWordSelector(ShowerPrefix);
        suf = randomWordSelector(ShowerSuffix);
        IMG1 = randomWordSelector(ShowerIMGs);
        IMG2 = randomWordSelector(ShowerIMGs);
        IMG3 = randomWordSelector(ShowerIMGs);
      }
      Article article = new Article
      {
        Name = $"{pre} {noun} {suf}",
        Price = randomPriceGenerator(minInt, maxInt, zeros),
        Description = lorem,
        Img1 = IMG1,
        Img2 = IMG2,
        Img3 = IMG3,
        Category = category,
      };
      return article;
    }
  }
}



