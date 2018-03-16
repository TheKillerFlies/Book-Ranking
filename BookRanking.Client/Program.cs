using System;
using System.Collections.Generic;
using System.Linq;
using BookRanking.Context;
using BookRanking.Data.Models;

namespace BookRanking.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BookRankingDbContext();

            //ctx.Users.First(u => u.Username == "vanko2").FavouriteCollection.Add(ctx.Books.First());
            //ctx.SaveChanges();
            Console.WriteLine(ctx.Users.First(u => u.Username == "vanko1").FavouriteCollection.Count);
        }
    }
}
