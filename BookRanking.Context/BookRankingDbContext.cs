using System.Data.Entity;
using BookRanking.Data.Models;

namespace BookRanking.Context
{
    public class BookRankingDbContext : DbContext, IBookRankingDbContext
    {
        public BookRankingDbContext() : base("BookRanking")
        {
        }

        public virtual IDbSet<Author> Authors { get; set; }

        public virtual IDbSet<Book> Books { get; set; }

        public virtual IDbSet<Publisher> Publishers { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                        .HasMany<User>(b => b.FavouriteUsers)
                        .WithMany(u => u.FavouriteCollection)
                        .Map(bu =>
                                {
                                    bu.MapLeftKey("BookRefId");
                                    bu.MapRightKey("UserRefId");
                                    bu.ToTable("BookUsers");
                                });
        }
    }
}
