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
    public class RemoveBookCommand : Command, ICommand
    {
        private readonly IBookService bookService;

        public RemoveBookCommand(IDTOFactory DTOFactory, IBookService bookService)
           : base(DTOFactory)
        {
            this.bookService = bookService;
        }
        public override string Execute(IList<string> parameters)
        {
            var title = parameters[0];
            var year = parameters[1];
            var book = this.DTOFactory.CreateBookDTO(title, int.Parse(year), null, null);
            this.bookService.RemoveBook(book);
            return Messages.bookRemoved;
        }
    }
}
