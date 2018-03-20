using System.Collections.Generic;

namespace BookRanking.DTO
{
    public class BookDTO
    {
        public string Title { get; set; }

        public int PublishedYear { get; set; }

        public ICollection<AuthorDTO> AuthorDTOs { get; set; }
    }
}
