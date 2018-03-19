using BookRanking.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRanking.Context
{
    public interface IBookRankingDbContext
    {
        IDbSet<Author> Authors { get; set; }

        IDbSet<Book> Books { get; set; }

        IDbSet<Publisher> Publishers { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        IDbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
