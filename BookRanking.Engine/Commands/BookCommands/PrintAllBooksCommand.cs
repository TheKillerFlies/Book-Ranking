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
    public class PrintAllBooksCommand : Command, ICommand
    {
        private readonly IBookService bookService;

        public PrintAllBooksCommand(IDTOFactory DTOFactory, IBookService bookService)
            : base(DTOFactory)
        {
            this.bookService = bookService;
        }
        public override string Execute(IList<string> parameters)
        {
            var books = this.bookService.GetAllBooks();
            return this.PrintBooks(books);
            
        }

        private string PrintBooks(IEnumerable<BookDTO> books)
        {
            var booksPrint = new StringBuilder();
            foreach (var book in books)
            {
                booksPrint.AppendLine(string.Format("Title:{0}, Year: {1}, Author: {2} {3}", book.Title, book.PublishedYear, book.Author.FirstName, book.Author.LastName));
            }

            return booksPrint.ToString();
        }
    }
}
