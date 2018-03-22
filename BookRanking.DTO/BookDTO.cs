using BookRanking.Common.MapperContracts;
using BookRanking.Data.Models;
using System.Collections.Generic;

namespace BookRanking.DTO
{
    public class BookDTO : IMapTo<Book>
    {
        public BookDTO()
        {
            this.AuthorDTOs = new HashSet<AuthorDTO>();
        }
        public string Title { get; set; }

        public int PublishedYear { get; set; }

        public ICollection<AuthorDTO> AuthorDTOs { get; set; }

        public Publisher Publisher { get; set; }
    }
}
