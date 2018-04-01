using BookRanking.DTO;
using BookRanking.Engine.Commands.Contracts;
using BookRanking.Engine.Factories.Contracts;
using BookRanking.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRanking.Engine.Commands.AuthorCommands
{
    public class PrintAllAuthorsCommand : Command, ICommand
    {
        private readonly IAuthorService authorService;

        public PrintAllAuthorsCommand(IDTOFactory DTOFactory, IAuthorService authorService)
            : base(DTOFactory)

        {
            this.authorService = authorService;
        }
        public override string Execute(IList<string> parameters)
        {
           var authors = this.authorService.GetAllAuthors();

            return this.PrintAuthors(authors);
        }

        private string PrintAuthors(IEnumerable<AuthorDTO> authors)
        {
            var authorsPrint = new StringBuilder();
            foreach (var author in authors)
            {
                authorsPrint.AppendLine(string.Format("Fist name: {0}, Last name: {1}", author.FirstName, author.LastName));
            }

            return authorsPrint.ToString();
        }
        
    }
}
