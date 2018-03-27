using Autofac;
using Autofac.Core;
using BookRanking.Client.ConsoleLoggerBook.Contracts;
using BookRanking.Client.Models.Contracts;
using BookRanking.Client.Models.Messages;
using BookRanking.DTO;
using BookRanking.Logic.Contracts;
using System;
using System.Reflection;

namespace BookRanking.Client.Models
{
    public class ScreenPrinter : IScreenPrinter
    {
        private IConsoleLogger logger;

        public ScreenPrinter(IConsoleLogger logger)
        {
            this.Logger = logger;
        }

        public IConsoleLogger Logger
        {
            get { return this.logger; }
            set { this.logger = value ?? throw new NullReferenceException(GlobalMessages.NullMessage); }
        }

        public void PrintStartScreen()
        {
            this.Logger.Write(GlobalMessages.WelcomeScreen);
            this.Logger.Write(GlobalMessages.ChooseCommand);
        }

        public void PrintChooseCommandScreen()
        {
            while (true)
            {
                string command = this.logger.Read();

                while (command != "1" && command != "2" && command != "3")
                {
                    this.Logger.Clear();
                    this.Logger.Write(GlobalMessages.WelcomeScreen);
                    //this.Logger.Write(GlobalMessages.InvalidCommandInput);
                    this.Logger.Write(GlobalMessages.ChooseCommand);
                    command = this.Logger.Read();
                }

                var builder = new ContainerBuilder();
                builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
                var container = builder.Build();

                switch (command)
                {
                    case "1":
                        var service = container.Resolve<IAuthorService>();
                        var authors = service.GetAllAuthors();

                        foreach (var author in authors)
                        {
                            this.Logger.Write(author.FirstName + " " + author.LastName);
                        }
                        continue;

                    case "2":
                        var serviceBook = container.Resolve<IBookService>();
                        var books = serviceBook.GetAllBooks();
                        foreach (var book in books)
                        {
                            this.Logger.Write(book.Title + " " + book.PublishedYear);
                        }
                        continue;

                    case "3":
                        var serviceAuthor = container.Resolve<IAuthorService>();

                        this.Logger.Write("Author FirstName:");
                        var first = this.Logger.Read();
                        this.Logger.Write("Author LastName:");
                        var last = this.Logger.Read();
                        this.Logger.Write("Author Alias:");
                        var alias = this.Logger.Read();

                        var authorToAdd = new AuthorDTO
                        {
                            FirstName = first,
                            LastName = last,
                            Alias = alias
                        };

                        serviceAuthor.AddAuthor(authorToAdd);
                        continue;
                }
            }
        }
    }
}
