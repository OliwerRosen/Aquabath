using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Data
{
  public static class ArticleItemGenerator
  {
    public static List<ArticleItem> createArticleItems(Article article)
    {
      int maxInStock = 12;
      int nrInStock = 0;
      int nrOutOfStock;
      List<ArticleItem> articleItems = new List<ArticleItem>();
      for (int year = 2022; year > 2018; year--)
      {
        ArticleItem articleItem;
        nrInStock = 0;
        if (year == 2022)
        {
          nrInStock = 7;
        }
        nrOutOfStock = maxInStock - nrInStock;
        for (int i = 0; i < nrInStock; i++)
        {
          articleItem = createArticleItem(year, true, article);
          articleItems.Add(articleItem);
        }
        for (int i = 0; i < nrOutOfStock; i++)
        {
          articleItem = createArticleItem(year, false, article);
          articleItems.Add(articleItem);
        }
      }
      return articleItems;
    }

    public static ArticleItem createArticleItem(int yearSold, bool isInStock, Article article)
    {
      string monthSold = randomDateFragment(11, 1, "");
      string daySold = randomDateFragment(27, 1, "");
      Int32.TryParse(monthSold, out int monthSoldInt);
      Int32.TryParse(daySold, out int daySoldInt);
      //string dayArrivedInStock = randomDateFragment(7, daySoldInt, "arrived");
      string dayArrivedInStock = randomDateFragment(27, 1, "");
      string monthArrivedInStock = randomDateFragment(monthSoldInt - 1, 1, "");
      string dayLeftStock = randomDateFragment(7, daySoldInt, "left");
      string monthLeftStock = monthSold;
      int dayLeftStockInt;
      int monthLeftStockInt = monthSoldInt;
      int yearLeftStock = yearSold;
      int yearArrivedInStock = yearSold;
      if (daySoldInt > 24)
      {
        if (monthSoldInt == 11)
        {
          yearLeftStock = (yearSold++);
        }
        monthLeftStockInt++;
        if (monthLeftStockInt < 10)
        {
          monthLeftStock = $"0{monthLeftStockInt}";
        }
        else
        {
          monthLeftStock = (monthLeftStockInt).ToString();
        }
        dayLeftStockInt = (28 - daySoldInt);
        if (dayLeftStockInt < 10)
        {
          dayLeftStock = $"0{dayLeftStockInt}";
        }
      }
      if (monthSoldInt == 1)
      {
        yearArrivedInStock = (yearSold--);
        monthArrivedInStock = randomDateFragment(11, 1, "");
      }
      string dateSold = "";
      string dateLeftStock = "";
      if (isInStock == false)
      {
        dateSold = createDate(yearSold, monthSold, daySold);
        dateLeftStock = createDate(yearLeftStock, monthLeftStock, dayLeftStock);
      }
      string dateArrivedInStock = createDate(yearArrivedInStock, monthArrivedInStock, dayArrivedInStock);

      ArticleItem articleitem = new ArticleItem
      {
        IsInStock = isInStock,
        DateSold = dateSold,
        DateLeftStock = dateLeftStock,
        DateArrivedInStock = dateArrivedInStock,
        Article = article,
      };
      return articleitem;
    }
    public static string createDate(int year, string month, string day)
    {
      string hour = randomDateFragment(24, 0, "");
      string minute = randomDateFragment(60, 0, "");
      string second = randomDateFragment(60, 0, "");
      string millisecond = randomDateFragment(1000, 0, "ms");
      string date = $"{year}-{month}-{day}T{hour}:{minute}:{second}.{millisecond}Z";
      return date;
    }
    public static string randomDateFragment(int maxValue, int extraValue, string typeValue)
    {
      Random rand = new Random();
      int fragment = rand.Next(maxValue) + extraValue;
      // if (dayValue == "arrived")
      // {
      //   fragment = extraValue - rand.Next(maxValue);
      // }
      if (typeValue == "left")
      {
        fragment = rand.Next(maxValue) + extraValue;
      }
      if (typeValue == "ms" && fragment < 100)
      {
        string newFragment = "";
        if (fragment < 100)
        {
          newFragment = $"0{fragment}";
        }
        if (fragment < 10)
        {
          newFragment = $"00{fragment}";
        }
        return newFragment;
      }
      if (fragment <= 9)
      {
        string newFragment = $"0{fragment}";
        return newFragment;
      }
      else
      {
        return fragment.ToString();
      }
    }
  }
}