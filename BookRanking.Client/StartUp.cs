using System;
using System.Data.Entity;
using BookRanking.Context;
using BookRanking.Context.Migrations;
using Autofac;
using System.Reflection;
using BookRanking.Common;
using BookRanking.Logic.Contracts;
using BookRanking.DTO;

namespace BookRanking.Client
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Init();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            var container = builder.Build();

            var bookService = container.Resolve<IBookService>();
            var author = new AuthorDTO
            {
                FirstName = "Pesho",
                LastName = "S",
                Alias = "It"
            };
            var bookToAdd = new BookDTO
            {
                Title = "Itrr",
                PublishedYear = 1970,
                AuthorDTOs =
                {
                    author
                }

            };

            bookService.AddBook(bookToAdd);
            //var service = container.Resolve<IAuthorService>();

            //var authors = service.GetAllAuthors();

            //foreach (var author in authors)
            //{
            //    Console.WriteLine(author.LastName);
            //}

            //var addedAuthorModel = new AuthorDTO
            //{
            //    FirstName = "P",
            //    LastName = "S",
            //    Alias = "It"
            //};


            //service.AddAuthor(addedAuthorModel);
        }

        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookRankingDbContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }
    }
}
