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

            return "";
        }
        
    }
}
