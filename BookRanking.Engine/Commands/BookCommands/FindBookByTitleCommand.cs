using BookRanking.DTO;
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
    public class FindBookByTitleCommand : Command, ICommand
    {
        private readonly IBookService bookService;

        public FindBookByTitleCommand(IDTOFactory DTOFactory, IBookService bookService)
           : base(DTOFactory)
        {
            this.bookService = bookService;
        }
        public override string Execute(IList<string> parameters)
        {
            var title = parameters[0];
            var book = this.bookService.FindBookByTitle(title);
            return this.PrintBook(book);
        }

        private string PrintBook(BookDTO book)
        {
            return string.Format("Author: {0} {1}, Year:{2}", book.Author.FirstName, book.Author.LastName, book.PublishedYear);
        }
    }
}
