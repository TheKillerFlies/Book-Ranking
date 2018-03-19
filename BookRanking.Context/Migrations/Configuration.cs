namespace BookRanking.Context.Migrations
{
    using BookRanking.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BookRanking.Context.BookRankingDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookRanking.Context.BookRankingDbContext context)
        {
            //context.Authors.AddOrUpdate(
            //   new Author() { FirstName = "Pencho", LastName = "Bobkov" },
            //   new Author() { FirstName = "Lara", LastName = "Croft" }
            //   );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
