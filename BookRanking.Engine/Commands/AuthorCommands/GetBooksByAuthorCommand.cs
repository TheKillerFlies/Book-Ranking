using BookRanking.DTO;
using BookRanking.Engine.Commands.Contracts;
using BookRanking.Engine.Factories.Contracts;
using BookRanking.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRanking.Engine.Commands
{
    public class GetBooksByAuthorCommand : Command, ICommand
    {
        private readonly IAuthorService authorService;

        public GetBooksByAuthorCommand(IDTOFactory DTOFactory, IAuthorService authorService)
            :base(DTOFactory)
        {
            this.authorService = authorService;
        }

        public override string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var alias = parameters[2];

            var author = this.DTOFactory.CreateAuthorDTO(firstName, lastName, alias);
            var books = this.authorService.GetBooksByAuthor(author);
         
            return this.PrintBooks(books);
        }

        private string PrintBooks(IEnumerable<BookDTO> books)
        {
            var booksPrint = new StringBuilder();
            foreach (var book in books)
            {
                booksPrint.AppendLine(string.Format("Title: {0} Year: {1}", book.Title, book.PublishedYear));
            }

            return booksPrint.ToString();
        }
    }
}
