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
    public class GetAllAuthorsCommand : ICommand
    {
        private readonly IDTOFactory DTOFactory;
        private IAuthorService authorService;

        public GetAllAuthorsCommand(IDTOFactory DTOFactory, IAuthorService authorService)
        {
            this.DTOFactory = DTOFactory;
            this.authorService = authorService;
        }
        public object Execute(IList<string> parameters)
        {
           var authors = this.authorService.GetAllAuthors();

            return authors;
        }
        
    }
}
