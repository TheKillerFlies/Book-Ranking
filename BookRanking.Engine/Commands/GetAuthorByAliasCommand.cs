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
    public class GetAuthorByAliasCommand : ICommand
    {
        private readonly IDTOFactory DTOFactory;
        private IAuthorService authorService;

        public GetAuthorByAliasCommand(IDTOFactory DTOFactory, IAuthorService authorService)
        {
            this.DTOFactory = DTOFactory;
            this.authorService = authorService;
        }

        public object Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
