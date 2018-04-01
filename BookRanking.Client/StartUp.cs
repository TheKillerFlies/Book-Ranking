using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using BookRanking.Context;
using BookRanking.Context.Migrations;
using AutoMapper;
using Autofac;
using BookRanking.Common;
using BookRanking.DTO;
using BookRanking.Logic;
using BookRanking.Client.AutofacModules;
using BookRanking.Data.Models;
using BookRanking.Engine.Commands.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        }

        private static void FillDbUsingJsonFiles(BookRankingDbContext context, AuthorService authorService, PublisherService publisherService, BookService bookService)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var settings = new JsonSerializerSettings();
                    settings.TypeNameHandling = TypeNameHandling.Auto;

                    var file = File.ReadAllText("publishers.json");
                    var publishers = ((JArray)JsonConvert.DeserializeObject(file, settings)).ToObject<List<PublisherDTO>>();

                    foreach (var publisher in publishers)
                    {
                        publisherService.AddPublisher(publisher);
                    }

                    file = File.ReadAllText("authors.json");
                    var authors = ((JArray)JsonConvert.DeserializeObject(file, settings)).ToObject<List<AuthorDTO>>();

                    foreach (var author in authors)
                    {
                        authorService.AddAuthor(author);
                    }

                    file = File.ReadAllText("book.json");
                    var books = ((JArray)JsonConvert.DeserializeObject(file, settings)).ToObject<List<BookDTO>>();

                    foreach (var book in books)
                    {
                        bookService.AddBook(book);
                    }

                    context.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                }
            }
        }

        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookRankingDbContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }
    }
}
