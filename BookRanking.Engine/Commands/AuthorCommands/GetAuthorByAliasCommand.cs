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
    public class GetAuthorByAliasCommand :Command, ICommand
    {
        private readonly IAuthorService authorService;

        public GetAuthorByAliasCommand(IDTOFactory DTOFactory, IAuthorService authorService)
            :base(DTOFactory)
        {
            this.authorService = authorService;
        }

        public override string Execute(IList<string> parameters)
        {
            var alias = parameters[0];
            var author = this.authorService.GetAuthorByAlias(alias);
            return string.Format("{0} {1}", author.FirstName, author.LastName);
        }
    }
}
