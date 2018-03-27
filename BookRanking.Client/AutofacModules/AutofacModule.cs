using Autofac;
using AutoMapper;
using BookRanking.Client.ConsoleLoggerBook;
using BookRanking.Client.ConsoleLoggerBook.Contracts;
using BookRanking.Client.Engine;
using BookRanking.Client.Engine.Contracts;
using BookRanking.Client.Models;
using BookRanking.Client.Models.Contracts;
using BookRanking.Context;
using BookRanking.Logic;
using BookRanking.Logic.Contracts;

namespace BookRanking.Client.AutofacModules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookRankingDbContext>().As<IBookRankingDbContext>().InstancePerDependency();
            builder.RegisterType<ScreenPrinter>().As<IScreenPrinter>().SingleInstance();
            builder.RegisterType<ConsoleLogger>().As<IConsoleLogger>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>().SingleInstance();
            builder.RegisterType<ConsoleReader>().As<IConsoleReader>().SingleInstance();
            builder.RegisterType<AuthorService>().As<IAuthorService>().InstancePerDependency();
            builder.RegisterType<BookService>().As<IBookService>().InstancePerDependency();
            builder.RegisterType<PublisherService>().As<IPublisherService>().InstancePerDependency();
            builder.RegisterType<BookEngine>().As<IBookEngine>().SingleInstance();
            builder.Register(x => Mapper.Instance);
        }
    }
}
