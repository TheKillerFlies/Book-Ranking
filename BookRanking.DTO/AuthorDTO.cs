using BookRanking.Common.MapperContracts;
using BookRanking.Data.Models;

namespace BookRanking.DTO
{
    public class AuthorDTO : IMapTo<Author>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
