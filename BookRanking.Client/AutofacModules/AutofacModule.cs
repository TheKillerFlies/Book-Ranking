using Autofac;
using AutoMapper;
using BookRanking.Client.Engine;
using BookRanking.Client.Engine.Contracts;
using BookRanking.Client.Models;
using BookRanking.Context;
using BookRanking.Engine.Commands;
using BookRanking.Engine.Commands.Contracts;
using BookRanking.Engine.Engine;
using BookRanking.Engine.Engine.Contracts;
using BookRanking.Engine.Factories;
using BookRanking.Engine.Factories.Contracts;
using BookRanking.Logic;
using BookRanking.Logic.Contracts;

namespace BookRanking.Client.AutofacModules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => Mapper.Instance);
            builder.RegisterType<BookRankingDbContext>().As<IBookRankingDbContext>().InstancePerDependency();
            builder.RegisterType<ConsoleRenderer>().As<IRenderer>().SingleInstance();
            builder.RegisterType<AuthorService>().As<IAuthorService>().InstancePerDependency();
            builder.RegisterType<BookService>().As<IBookService>().InstancePerDependency();
            builder.RegisterType<PublisherService>().As<IPublisherService>().InstancePerDependency();
            builder.RegisterType<BookEngine>().As<IBookEngine>().SingleInstance();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();
            builder.RegisterType<DTOFactory>().As<IDTOFactory>().SingleInstance();
            builder.RegisterType<AddAuthorCommand>().Named<ICommand>("addаuthor").InstancePerDependency();
        }
    }
}
