using System;
using System.Data.Entity;
using BookRanking.Context;
using BookRanking.Context.Migrations;
using Autofac;
using System.Reflection;
using BookRanking.Common;
using BookRanking.Logic.Contracts;
using BookRanking.DTO;
using BookRanking.Logic;
using BookRanking.Client.Engine.Contracts;
using BookRanking.Client.Engine;
using BookRanking.Client.Models;
using BookRanking.Client.Models.Contracts;
using BookRanking.Client.ConsoleLoggerBook;
using BookRanking.Client.ConsoleLoggerBook.Contracts;
using BookRanking.Client.AutofacModules;

namespace BookRanking.Client
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Init();

            var builder = new ContainerBuilder();
            //builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            var injectionConfig = new AutofacModule();
            builder.RegisterModule<AutofacModule>();

            var container = builder.Build();

            var bookService = container.Resolve<IBookService>();
            var authorService = container.Resolve<IAuthorService>();
            var publisherService = container.Resolve<IPublisherService>();

           // var engine = container.Resolve<IBookEngine>();

            //engine.Start();

            var author = new AuthorDTO
            {
                FirstName = "sfsg",
                LastName = "S",
                Alias = "It"
            };

            var publisher = new PublisherDTO
            {
                Name = "khhхh"
            };

            var bookToAdd = new BookDTO
            {
                Title = "huhuhхu1",
                PublishedYear = 1970,
                AuthorDTOs = { author },
                Publisher = publisher
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
