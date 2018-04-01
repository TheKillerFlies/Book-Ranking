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
    public class AddAuthorCommand :Command, ICommand
    {
        private readonly IDTOFactory DTOFactory;
        private readonly IAuthorService authorService;
        public AddAuthorCommand(IDTOFactory DTOFactory, IAuthorService authorService)
            : base(DTOFactory)

        {
            this.DTOFactory = DTOFactory;
            this.authorService = authorService;
        }

        public override object Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var alias = parameters[2];

            var author = this.DTOFactory.CreateAuthorDTO(firstName, lastName, alias);
            authorService.AddAuthor(author);
            return null;
        }
    }
}
