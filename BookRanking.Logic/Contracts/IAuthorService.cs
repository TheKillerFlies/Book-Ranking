using BookRanking.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BookRanking.Logic.Contracts
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDTO> GetAllAuthors();

        void AddAuthor(AuthorDTO author);

        void RemoveAuthor(AuthorDTO author);

        AuthorDTO GetAuthorByAlias(string alias);

        IEnumerable<BookDTO> GetBooksByAuthor(AuthorDTO authorDTO);
    }
}
