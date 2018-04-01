using Autofac;
using AutoMapper;
using BookRanking.Client.Engine;
using BookRanking.Client.Engine.Contracts;
using BookRanking.Client.Models;
using BookRanking.Common.Utils;
using BookRanking.Common.Utils.Contracts;
using BookRanking.Context;
using BookRanking.Engine.Commands;
using BookRanking.Engine.Commands.AuthorCommands;
using BookRanking.Engine.Commands.BookCommands;
using BookRanking.Engine.Commands.Contracts;
using BookRanking.Engine.Commands.PublisherCommands;
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
            builder.RegisterType<PdfExporter>().As<IPdfExporter>().InstancePerDependency();
            builder.RegisterType<AddAuthorCommand>().Named<ICommand>("addauthor").InstancePerDependency();
            builder.RegisterType<PrintAllAuthorsCommand>().Named<ICommand>("printallauthors").InstancePerDependency();
            builder.RegisterType<PrintBooksByAuthorCommand>().Named<ICommand>("getbooksbyauthor").InstancePerDependency();
            builder.RegisterType<RemoveAuthorCommand>().Named<ICommand>("removeauthor").InstancePerDependency();
            builder.RegisterType<AddPublisherCommand>().Named<ICommand>("addpublisher").InstancePerDependency();
            builder.RegisterType<PrintAllPublishersCommand>().Named<ICommand>("getallpublishers").InstancePerDependency();
            builder.RegisterType<RemovePublisherCommand>().Named<ICommand>("removepublisher").InstancePerDependency();
            builder.RegisterType<AddBookCommand>().Named<ICommand>("addbook").InstancePerDependency();
            builder.RegisterType<FindBookByTitleCommand>().Named<ICommand>("findbookbytitle").InstancePerDependency();
            builder.RegisterType<PrintAllBooksCommand>().Named<ICommand>("printallbooks").InstancePerDependency();
            builder.RegisterType<RemoveBookCommand>().Named<ICommand>("removebook").InstancePerDependency();
            builder.RegisterType<ExportAllAuthorsCommand>().Named<ICommand>("exportallauthors").InstancePerDependency();


        }
    }
}
