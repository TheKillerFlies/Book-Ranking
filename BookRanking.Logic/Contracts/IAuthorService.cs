using BookRanking.DTO;
using System.Linq;

namespace BookRanking.Logic.Contracts
{
    public interface IAuthorService
    {
        IQueryable<AuthorDTO> GetAllAuthors();

        void AddAuthor(AuthorDTO author);

        AuthorDTO GetAuthorByAlias(string alias);
    }
}
