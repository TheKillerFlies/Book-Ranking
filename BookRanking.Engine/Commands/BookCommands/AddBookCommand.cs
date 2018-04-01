using BookRanking.Engine.Commands.Contracts;
using BookRanking.Engine.Factories.Contracts;
using BookRanking.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRanking.Engine.Commands.BookCommands
{
    public class AddBookCommand : Command, ICommand
    {

        private readonly IBookService bookService;

        public AddBookCommand(IDTOFactory DTOFactory, IBookService bookService)
            : base(DTOFactory)
        {
            this.bookService = bookService;
        }

        public override string Execute(IList<string> parameters)
        {
            
            var title = parameters[0];
            var year = parameters[1];
            var publisherName = parameters[2];
            var authorFirstName = parameters[3];
            var authorLastName = parameters[4];
            var alias = parameters[5];
            var publisher = this.DTOFactory.CreatePublisherDTO(publisherName);
            var author = this.DTOFactory.CreateAuthorDTO(authorFirstName, authorLastName, alias);
            var book = this.DTOFactory.CreateBookDTO(title, int.Parse(year), publisher, author);
            this.bookService.AddBook(book);
            return Messages.BookAdded;
        }
    }
}
