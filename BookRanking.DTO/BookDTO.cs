using AutoMapper;
using BookRanking.Common.MapperContracts;
using BookRanking.Data.Models;
using System.Collections.Generic;

namespace BookRanking.DTO
{
    public class BookDTO :  IMapTo<Book>
    {
        public BookDTO(string title, int publishedYear, PublisherDTO publisher)
        {
            this.Title = title;
            this.PublishedYear = publishedYear;
            this.AuthorDTOs = new HashSet<AuthorDTO>();
            this.Publisher = publisher;
        }
        public string Title { get; private set; }

        public int PublishedYear { get; private set; }

        public ICollection<AuthorDTO> AuthorDTOs { get; private set; }

        public PublisherDTO Publisher { get; private set; }

    
    }
}
