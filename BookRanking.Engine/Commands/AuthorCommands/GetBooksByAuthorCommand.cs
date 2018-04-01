using BookRanking.Engine.Commands.Contracts;
using BookRanking.Engine.Factories.Contracts;
using BookRanking.Logic.Contracts;
using System.Collections.Generic;

namespace BookRanking.Engine.Commands
{
    public class GetBooksByAuthorCommand : Command, ICommand
    {
        private readonly IDTOFactory DTOFactory;
        private readonly IAuthorService authorService;

        public GetBooksByAuthorCommand(IDTOFactory DTOFactory, IAuthorService authorService)
            :base(DTOFactory)
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
            var books = this.authorService.GetBooksByAuthor(author);

            return books;
        }
    }
}
