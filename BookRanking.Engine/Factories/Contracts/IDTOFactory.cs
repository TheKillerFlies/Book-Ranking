using BookRanking.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRanking.Engine.Factories.Contracts
{
    public interface IDTOFactory
    {
        AuthorDTO CreateAuthorDTO(string firstName, string lastName, string alias);
        BookDTO CreateBookDTO(string title, int publishedYear, PublisherDTO publisher);
        PublisherDTO CreatePublisherDTO(string name);
    }
}
