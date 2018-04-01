using BookRanking.DTO;
using BookRanking.Engine.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRanking.Engine.Factories
{
    public class DTOFactory : IDTOFactory
    {
        public AuthorDTO CreateAuthorDTO(string firstName, string lastName, string alias)
        {
            return new AuthorDTO(firstName, lastName, alias);
        }

        public BookDTO CreateBookDTO(string title, int publishedYear, PublisherDTO publisher, AuthorDTO author)
        {
            return new BookDTO(title, publishedYear, publisher, author);
        }

        public PublisherDTO CreatePublisherDTO(string name)
        {
            return new PublisherDTO(name);
        }
    }
}
