using System;
using System.Data.Entity;
using BookRanking.Context;
using BookRanking.Context.Migrations;
using AutoMapper;
using Autofac;
using System.Reflection;
using BookRanking.Common;
using BookRanking.Logic.Contracts;
using BookRanking.DTO;
using BookRanking.Logic;
using BookRanking.Client.AutofacModules;
using BookRanking.Client.Engine.Contracts;
using BookRanking.Engine.Commands.Contracts;
using System.Collections.Generic;

namespace BookRanking.Client
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Init();
            var builder = new ContainerBuilder();
            var injectionConfig = new AutofacModule();
            builder.RegisterModule(injectionConfig);
            var container = builder.Build();
            var context = new BookRankingDbContext();
            var authorService = new AuthorService(context, Mapper.Instance);
            var publisherService = new PublisherService(context, Mapper.Instance);
            var bookService = new BookService(authorService, publisherService, context, Mapper.Instance);

            //var comm = container.ResolveNamed<ICommand>("addauthor");
            //var engine = container.Resolve<IBookEngine>();

            //engine.Start();

            var publisher = new PublisherDTO("khh35");
            var author = new AuthorDTO("Strphen", "Knig", "It");
            var book = new BookDTO("TheLake", 2000, publisher, author);

            //authorService.AddAuthor(new AuthorDTO("Strphen", "Knig", "It"));

            //var authors = authorService.GetAllAuthors();
            //foreach (var item in authors)
            //{
            //    Console.WriteLine(item.FirstName);
            //}

            //bookService.AddBook(book, author, publisher);

            var aa = authorService.GetAuthorByAlias("alias34");
            Console.WriteLine(aa.FirstName);
            //var authors = authorService.GetAllAuthors();
            //foreach (var item in authors)
            //{
            //    Console.WriteLine(item.FirstName);
            //}

            //var books = authorService.GetBooksByAuthor("Strphen", "Knig");
            //foreach (var item in books)
            //{
            //    Console.WriteLine(item.Title);
            //}
            //var books = authorService.GetBooksByAuthor("fname", "lname");
            //foreach (var item in books)
            //{
            //    Console.WriteLine(item.Title);
            //}
            //var b = bookService.FindBookByTitle("kniga1");
            //Console.WriteLine(b.Publisher.Name);


        }

        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookRankingDbContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }
    }
}
